using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Albums",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Albums",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Albums",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Albums",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Albums",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CreatedById",
                table: "Albums",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ModifiedById",
                table: "Albums",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_CreatedById",
                table: "Albums",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_ModifiedById",
                table: "Albums",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_CreatedById",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_ModifiedById",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_CreatedById",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ModifiedById",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Albums");
        }
    }
}
