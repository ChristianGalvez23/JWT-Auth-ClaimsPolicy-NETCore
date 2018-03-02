using System;
using System.ComponentModel.DataAnnotations;

namespace business.Models {
    public class LoginModel : BaseModel {
        public UserModel User { get; set; }
        public Guid PermissionId { get; set; }
        public PermissionModel Permission { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength (6)]
        public string Password { get; set; }
    }
}