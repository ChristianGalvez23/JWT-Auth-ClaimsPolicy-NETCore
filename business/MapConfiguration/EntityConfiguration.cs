using System;
using AutoMapper;
using business.Models;
using domain;

namespace business.MapConfiguration {
    public class EntityConfiguration : Profile {
        public EntityConfiguration () {
            CreateMap<UserModel, User> ();
            CreateMap<User, UserModel> ();
            CreateMap<LoginModel, Login> ();
            CreateMap<Login, LoginModel> ();
            CreateMap<PermissionModel, Permission> ();
            CreateMap<Permission, PermissionModel> ();

        }
    }
}