using AutoMapper;
using FirebaseAdmin.Messaging;
using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Models;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.FCM
{
    public class FCMService : IFCMService
    {
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;
        public FCMService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<bool> CheckDevice(int empId, string deviceId)
        {
            EmployeeDevice device = await _uow.DeviceRepository.GetFirst(filter: el => el.DeviceId == deviceId && el.EmpId == empId);
        
            if (device == null)
            {
                EmployeeDevice newDevice = new EmployeeDevice()
                {
                    EmpId = empId,
                    DeviceId = deviceId
                };
                _uow.DeviceRepository.Add(newDevice);
            }
            else
            {
                device.DeviceId = deviceId;
                _uow.DeviceRepository.Update(device);
            }
            return await _uow.SaveAsync() > 0;
        }

        public async Task SendMessage(int empId, string title, string body)
        {
            IEnumerable<EmployeeDevice> device = await _uow.DeviceRepository.Get(filter: el => el.EmpId == empId);
            if (device != null)
            {
                List<EmployeeDevice> list = new List<EmployeeDevice>(device);
                List<Message> messages = new List<Message>();
                if (list.Count > 0)
                {
                    list.ForEach(device =>
                    {
                        messages.Add(new Message()
                        {
                            Notification = new Notification()
                            {
                                Title = title,
                                Body = body
                            },
                            Token = device.DeviceId
                        });
                    });
                    await FirebaseMessaging.DefaultInstance.SendAllAsync(messages);
                }
            }
        }

        public async Task SendMessageAll(IEnumerable<DeviceDto> deviceRequest,string title, string body)
        {
            if (deviceRequest == null)
            {
                throw new Exception("List Devices are null");
            }
            IEnumerable<EmployeeDevice> device = _mapper.Map<IEnumerable<EmployeeDevice>>(deviceRequest);
            List<EmployeeDevice> list = new List<EmployeeDevice>(device);
            List<Message> messages = new List<Message>();
            if (list.Count > 0)
            {
                list.ForEach(device =>
                {
                    messages.Add(new Message()
                    {
                        Notification = new Notification()
                        {
                            Title = title,
                            Body = body
                        },
                        Token = device.DeviceId
                    });
                });
                await FirebaseMessaging.DefaultInstance.SendAllAsync(messages);
            }
        }
    }
}
