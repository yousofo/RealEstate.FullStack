using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersWithRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "12121212abc", "test@test.com", true, "Youssef", "Elmoussaoui", false, null, "TEST@TEST.COM", "YOUSSEF1", "AQAAAAIAAYagAAAAEE7iAGoK16nHp2rWZElaHIXjcIv3nJnC2TCVblYlPBfaEXtv5/fCHjb7wIR6HQX8Ag==", "123456789", true, "", false, "youssef1" },
                    { "2", 0, "12121212bca", "admin@test.com", true, "Youssef", "Elmoussaoui", false, null, "ADMIN@TEST.COM", "YOUSSEF2", "AQAAAAIAAYagAAAAEE7iAGoK16nHp2rWZElaHIXjcIv3nJnC2TCVblYlPBfaEXtv5/fCHjb7wIR6HQX8Ag==", "1234567890", true, "", false, "youssef2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "3", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
