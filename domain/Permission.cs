using System;
using System.Collections.Generic;
using domain;

namespace domain {
    public class Permission {
        public Permission () {
            this.Logins = new List<Login> ();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Login> Logins { get; set; }
    }
}