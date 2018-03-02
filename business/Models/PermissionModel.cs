using System;
using System.Collections.Generic;
using domain;

namespace business.Models {
    public class PermissionModel : BaseModel {
        public PermissionModel () {
            this.Logins = new List<Login> ();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Login> Logins { get; set; }
    }
}