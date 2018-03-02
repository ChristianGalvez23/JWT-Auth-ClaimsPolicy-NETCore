using System;

namespace domain {
    public class User {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BornDate { get; set; }
        public bool Male { get; set; }
        public DateTime SignUpDate { get; set; }

        public Login Login { get; set; }
    }
}