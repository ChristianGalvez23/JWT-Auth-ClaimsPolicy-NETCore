using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using business.Context;
using business.MapConfiguration;
using business.Models;
using domain;
using Microsoft.EntityFrameworkCore;

namespace business {
    public class Business : IBusiness {
        public AppDbContext _context { get; }

        public Business (AppDbContext context) {
            Mapper.Reset ();
            Mapper.Initialize (cfg => cfg.AddProfile<EntityConfiguration> ());
            this._context = context;
        }

        public HttpMessageModel SignIn (LoginModel model) {
            var login = Mapper.Map<Login> (model);
            var loginFound = this._context.Logins.FirstOrDefault (l => l.Email == model.Email);
            if (loginFound == null || loginFound.Password != model.Password) {
                return new HttpMessageModel {
                Code = MessageStatusCode.NotFound,
                Message = "Invalid email/password.",
                Model = model
                };
            }
            return new HttpMessageModel {
                Code = MessageStatusCode.OK,
                    Message = "Ok",
                    Model = Mapper.Map<LoginModel> (loginFound)
            };
        }

        public async Task<HttpMessageModel> Register (UserModel model) {
            var user = Mapper.Map<User> (model);
            user.SignUpDate = DateTime.Now;
            this._context.Users.Add (user);
            try {
                await this._context.SaveChangesAsync ();
            } catch (DbUpdateException err) {
                return new HttpMessageModel {
                    Model = model,
                        Message = "Error while saving user.",
                        Code = MessageStatusCode.Error
                };
            }
            return new HttpMessageModel {
                Model = model,
                    Message = "User registered succesfully.",
                    Code = MessageStatusCode.OK
            };
        }
    }
}