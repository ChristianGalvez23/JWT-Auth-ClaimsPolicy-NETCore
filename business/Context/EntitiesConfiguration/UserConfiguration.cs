using System;
using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace business.Context.EntitiesConfiguration {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure (EntityTypeBuilder<User> builder) {
            builder.ToTable ("User");
            builder.HasKey (k => k.Email);
            builder.Property (p => p.Male).HasColumnType ("bit");
            builder.Property (p => p.BornDate).HasColumnType ("Date");
            builder.Property (p => p.SignUpDate).HasColumnType ("Date");

            builder.HasOne (l => l.Login)
                .WithOne (l => l.User)
                .HasForeignKey<Login> (fk => fk.Email);
        }
    }
}