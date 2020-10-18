using Scheduling.Data.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.FCM
{
    public interface IFCMService
    {
        public Task<bool> CheckDevice(int empId, string deviceId);

        public Task SendMessage(int empId, string title, string body);

        public Task SendMessageAll(IEnumerable<DeviceDto> device, string title, string body);

    }
}
