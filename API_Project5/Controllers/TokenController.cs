using API_Project5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly Iterior_DesignContext _context;

        public TokenController(IConfiguration config, Iterior_DesignContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Post(Users users)
        {

            if (users.UserName != null && users.Password != null)
            {
                var user = await GetUser(users.UserName, users.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    //
                    new Claim("Id", user.IdUser.ToString()),
                    new Claim("FullName", user.Name),
                    new Claim("UserName", user.UserName),
                    //new Claim("Email", users.Email),
                      new Claim(ClaimTypes.Role, users.Rol.ToString()),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new
                    {
                        user = new
                        {
                            userId = user.IdUser,
                            fullName = user.Name,
                            userName = user.UserName,
                            role = user.Rol,
                        },
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                       // JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Thông tin tài khoản chưa đúng");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Users> GetUser(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }

        //Người dùng


        [HttpPost]
        [Route("LoginCus")]
        public async Task<IActionResult> Post(Customers cus)
        {

            if (cus.EmailCus != null && cus.Password != null)
            {
                var customer = await GetUserCus(cus.EmailCus, cus.Password);

                if (customer != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    //
                    new Claim("Id", customer.IdCustomer.ToString()),
                    new Claim("FullName", customer.NameCus),
                    new Claim("UserName", customer.EmailCus),
                    //new Claim("Email", users.Email),
                      //new Claim(ClaimTypes.Role, users.Rol.ToString()),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var tokenCus = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new
                    {
                        customer = new
                        {
                            cusID = customer.IdCustomer,
                            fullName = customer.NameCus,
                            Email = customer.EmailCus,
                            phone = customer.PhoneCus,
                            address= customer.AddressCus,

                        },
                        tokenCus = new JwtSecurityTokenHandler().WriteToken(tokenCus)
                    });
                    // JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Thông tin tài khoản chưa đúng");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Customers> GetUserCus(string email, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(u => u.EmailCus == email && u.Password == password);
        }

    }
}