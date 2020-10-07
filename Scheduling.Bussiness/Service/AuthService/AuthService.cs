using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.VisualBasic;
using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Helper;
using Scheduling.Data.Models;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AuthService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Login(FirebaseToken userToken)
        {
            string email = userToken.Claims["email"].ToString();

            if (!AppUtils.CheckValidationEmail(email))
            {
                throw new ArgumentException("Wrong format input email");
            }

            Employee emp = await _uow.EmployeeRepository.GetFirst(filter: el => el.Email == email, includeProperties: "Role");

            // check if this email belongs to fpt.edu.vn

            if (emp == null)
            {
                _uow.EmployeeRepository.Add(new Employee()
                {
                    Email = email,
                    Fullname = userToken.Claims["name"].ToString(),
                    CreateTime = DateTime.Now,
                    RoleId = AppConstants.Roles.Employee.ID,
                });

                if (await _uow.SaveAsync() > 0)
                {
                    emp = await _uow.EmployeeRepository.GetFirst(filter: el => el.Email == email , includeProperties : "Role");
                }
                else
                {
                    throw new Exception("Create new account failed");
                }
            }
            return _mapper.Map<EmployeeDto>(emp);
        }


    }
}
