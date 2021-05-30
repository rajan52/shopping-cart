using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Model.Dto;
using ShoppingCart.Service;

namespace ShoppingCart.api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ICustomerService customerService;

        public IConfiguration _config = null;

        public LoginController(IConfiguration config, ICustomerService _customerService)
        {
            _config = config;
            this.customerService = _customerService;
        }
        public ActionResult Post(LoginDto loginDto)
        {
            try
            {
                var custdto = this.customerService.Login(loginDto);
                if (custdto != null)
                {
                    string token=GenerateJSONWebToken(custdto);
                    TokenDto tokenDto = new TokenDto { Token = token };
                    return Ok(tokenDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
               return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private string GenerateJSONWebToken(CustomerDto customerDto)
        {
            // when he is validated AD

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,Convert.ToString(customerDto?.Id)),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Role", "Admin"),
                new Claim("UserId",Convert.ToString(customerDto?.Id)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}