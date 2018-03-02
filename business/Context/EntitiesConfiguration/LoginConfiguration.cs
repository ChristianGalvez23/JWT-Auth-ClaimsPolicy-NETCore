using System;
using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace business.Context.EntitiesConfiguration {
    public class LoginConfiguration : IEntityTypeConfiguration<Login> {
        public void Configure (EntityTypeBuilder<Login> builder) {
            builder.ToTable ("Login");
            builder.HasKey (k => k.Email);

            builder.HasOne (p => p.Permission)
                .WithMany (p => p.Logins)
                .HasForeignKey (fk => fk.PermissionId);
        }
    }
}