using System;
using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace business.Context.EntitiesConfiguration {
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission> {
        public void Configure (EntityTypeBuilder<Permission> builder) {
            builder.ToTable ("Permission");
            builder.HasKey (k => k.Id);
        }
    }
}