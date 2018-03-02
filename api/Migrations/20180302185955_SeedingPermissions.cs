using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations {
    public partial class SeedingPermissions : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("INSERT INTO Permission VALUES('c013272e-251f-42fd-a565-8d24c90502c2', 'Admin');");
            migrationBuilder.Sql ("INSERT INTO Permission VALUES('cdf79ae2-3262-4d72-b712-ab6bb6b8d1dd', 'User');");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("DELETE FROM [Permission]");
        }
    }
}