using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Scheduling.Bussiness.Service.AuthService;
using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Helper;

namespace SchedulingProject.Controller
{
    [Route("api/v1/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Google")]
        public async Task<IActionResult> LoginGoogle(LoginDto login)
        {
            try
            {
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(login.Token);
                EmployeeDto emp = await _authService.Login(decodedToken);
                if (emp != null)
                {
                    var claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, emp.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, emp.Email),
                        new Claim(ClaimTypes.Role, emp.Role.Role1),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.Settings.JwtSecret));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(AppSettings.Settings.Issuer,
                                                        AppSettings.Settings.Audience,
                                                        claims,
                                                        // expires: DateTime.Now.AddSeconds(55 * 60),
                                                        signingCredentials: creds);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                else
                {
                    return Forbid();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
