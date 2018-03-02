using System;
using System.Threading.Tasks;
using business.Models;

namespace business {
    public interface IBusiness {
        HttpMessageModel SignIn (LoginModel login);
        Task<HttpMessageModel> Register (UserModel user);
    }
}