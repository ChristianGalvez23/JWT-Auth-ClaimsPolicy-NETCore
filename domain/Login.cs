using System;

namespace domain {
    public class Login {
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }

        public string Email { get; set; }
        public User User { get; set; }
        public string Password { get; set; }
    }
}