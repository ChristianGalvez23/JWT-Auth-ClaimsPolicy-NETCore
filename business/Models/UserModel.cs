using System;

namespace business.Models {
    public class UserModel : BaseModel {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BornDate { get; set; }
        public bool Male { get; set; }
        public DateTime SignUpDate { get; set; }

        public LoginModel Login { get; set; }
    }
}