using System;
using business.Context.EntitiesConfiguration;
using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace business.Context {
    public class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public AppDbContext (DbContextOptions options) : base (options) {

        }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.ApplyConfiguration<User> (new UserConfiguration ());
            builder.ApplyConfiguration<Login> (new LoginConfiguration ());
            builder.ApplyConfiguration<Permission> (new PermissionConfiguration ());
        }

    }
}