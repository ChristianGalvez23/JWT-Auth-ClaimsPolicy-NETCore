using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations {
    public partial class SeedingUsers : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("INSERT INTO [User] VALUES('jhon@int.com', '1991-05-15', 'Jhon Dous', 1, '" + DateTime.Now + "');");
            migrationBuilder.Sql ("INSERT INTO [Login] VALUES('jhon@int.com', '123456', 'c013272e-251f-42fd-a565-8d24c90502c2');");
            migrationBuilder.Sql ("INSERT INTO [User] VALUES('peter@int.com', '1990-02-23', 'Peter Cley', 1, '" + DateTime.Now + "');");
            migrationBuilder.Sql ("INSERT INTO [Login] VALUES('peter@int.com', '123456', 'cdf79ae2-3262-4d72-b712-ab6bb6b8d1dd');");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("Delete from [Login]");
            migrationBuilder.Sql ("Delete from [User]");
        }
    }
}