﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ChatterAPI.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserDataService _userDataService;
        public RegisterController(IConfiguration config, IUserDataService userDataService)
        {
            _configuration = config;
            _userDataService = userDataService;
        }

        [HttpPost]
        public IActionResult Post([Bind("Id, Password, Name")] User u)
        {
            foreach (User usr in _userDataService.GetAllUsers())
            {
                if (usr.Id == u.Id)
                {
                    return BadRequest("Username already exist");
                }
            }
            if(u.Id.Length == 0 || u.Password.Length == 0 || u.Name.Length == 0) {
                return BadRequest("Empty fields are not Allowed");
            }
            bool containsInt = u.Password.Any(char.IsDigit);
            bool containsLetter = u.Password.Any(char.IsLetter);
            if(!(containsInt && containsLetter))
            {
                return BadRequest("password must contains letters and digits");
            }

            User newUser = new User();
            newUser.Id = u.Id;
            newUser.Password = u.Password;
            newUser.Name = u.Name;
            _userDataService.AddNewUser(newUser);
            UserChats uC = new UserChats();
            uC.Username = newUser.Id;
            uC.Chats = new List<Chat>();
            _userDataService.AddUserChats(uC);
            var claims = new[] {
                                new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWTParams:Subject"]),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                                new Claim("UserId", u.Id)
                            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtParams:SecretKey"]));
            var mac = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JwtParams:Issuer"],
                _configuration["JwtParams:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: mac);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
