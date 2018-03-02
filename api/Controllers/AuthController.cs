using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using business;
using business.Context;
using business.Models;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers {
    public class AuthController : Controller {
        private IConfiguration _config;
        private IBusiness _business;
        public AuthController (IConfiguration config, AppDbContext context) {
            this._config = config;
            this._business = new Business (context);
        }

        [Route ("api/signin")]
        [HttpPost]
        public JsonResult SignIn ([FromBody] LoginModel login) {
            if (!ModelState.IsValid) {
                return Json ("Invalid user.");
            }
            HttpMessageModel result = this._business.SignIn (login);
            JsonResult token = Json ("User doen't exist.");
            if (result.Code == MessageStatusCode.OK) {
                token = GenerateToken (result.Model as LoginModel);
            }
            return Json (token);
        }

        private JsonResult GenerateToken (LoginModel login) {
            var claims = new List<Claim> {
                new Claim ("iss", this._config["Token:Issuer"]),
                new Claim ("aud", this._config["Token:Issuer"]),
                new Claim ("sub", login.Email),
                new Claim ("permission", login.PermissionId.ToString ())
            };

            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (this._config["Token:Key"]));
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken (
                issuer : this._config["Token:Issuer"],
                audience : this._config["Token:Audience"],
                claims : claims,
                expires : DateTime.Now.AddMinutes (3),
                signingCredentials : creds
            );

            return Json (new {
                token = new JwtSecurityTokenHandler ().WriteToken (token),
                    expiration = DateTime.Now.AddMinutes (3)
            });
        }

        [Route ("api/register")]
        [HttpPost]
        public async Task<JsonResult> Register ([FromBody] UserModel user) {
            if (!ModelState.IsValid) {
                return Json ("Invalid user.");
            }
            var result = await this._business.Register (user);
            return Json (result);
        }
    }
}