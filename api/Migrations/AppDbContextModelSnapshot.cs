﻿// <auto-generated />
using business.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("domain.Login", b =>
                {
                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<Guid>("PermissionId");

                    b.HasKey("Email");

                    b.HasIndex("PermissionId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("domain.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("domain.User", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("Date");

                    b.Property<string>("FullName");

                    b.Property<bool>("Male")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("Date");

                    b.HasKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("domain.Login", b =>
                {
                    b.HasOne("domain.User", "User")
                        .WithOne("Login")
                        .HasForeignKey("domain.Login", "Email")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("domain.Permission", "Permission")
                        .WithMany("Logins")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
