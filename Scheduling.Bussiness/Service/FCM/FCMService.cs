using FirebaseAdmin.Messaging;
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
        public FCMService(IUnitOfWork uow)
        {
            _uow = uow;
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
