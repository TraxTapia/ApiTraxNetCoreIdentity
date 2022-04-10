﻿using Api.Models.ApiWeb.Models;
using Api.Models.ApiWeb.Models.Identity;
using Api.Models.ApiWeb.Settings;
using Api.Repository.ApiWeb.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.ApiTrax.ApiWeb.Controllers
{


    [Route("api/Token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public IConfiguration _configuration;
        //private readonly DataBaseContext _context;
        CoreApi implement = null;
        private readonly IOptions<AppSettings> settings;

        private readonly ILogger logger;

        public TokenController(IOptions<AppSettings> _appSettings, ILogger<UsersController> logger)
        {
            implement = new CoreApi(_appSettings);
            settings = _appSettings;
            this.logger = logger;
        }



        //public TokenController(IConfiguration config, DataBaseContext context)
        //{
        //    _configuration = config;
        //    _context = context;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(UserInfo _userData)
        //{
        //    if (_userData != null && _userData.Email != null && _userData.Password != null)
        //    {
        //        var user = await GetUser(_userData.Email, _userData.Password);

        //        if (user != null)
        //        {
        //            //create claims details based on the user information
        //            var claims = new[] {
        //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                new Claim("UserId", user.UserId.ToString()),
        //                new Claim("DisplayName", user.DisplayName),
        //                new Claim("UserName", user.UserName),
        //                new Claim("Email", user.Email)
        //            };

        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //            var token = new JwtSecurityToken(
        //                _configuration["Jwt:Issuer"],
        //                _configuration["Jwt:Audience"],
        //                claims,
        //                expires: DateTime.UtcNow.AddMinutes(10),
        //                signingCredentials: signIn);

        //            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //        }
        //        else
        //        {
        //            return BadRequest("Invalid credentials");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpPost]
        public async Task<LoginResponseDTO> GetToken(UserInfo _userData)
        {
            //IOptions<AppSettings> appSettings;
            IOptions<AppSettings> _appSettings;

            LoginResponseDTO _Response = new LoginResponseDTO();

            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {

                var user = await implement.GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub,settings.Value.Jwt["Subject"] ),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Value.Jwt["Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                     settings.Value.Jwt["Issuer"],
                       settings.Value.Jwt["Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    _Response.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                    _Response.TokenType = "bearer";
                    _Response.ExpiresIn = token.ValidTo;
                    _Response.Username = user.UserName;
                    //Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    throw new Exception("Credenciales Invalidas");
                }
            }
            else
            {
                throw new Exception("Los parametros no pueden estar vacios");
            }
            return _Response;

        }

    }

}
