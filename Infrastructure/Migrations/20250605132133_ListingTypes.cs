using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ListingTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListingType",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "PropertyListingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyListingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyListingTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyListingTypes_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyPropertyListingType",
                columns: table => new
                {
                    ListingTypesId = table.Column<int>(type: "int", nullable: false),
                    PropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPropertyListingType", x => new { x.ListingTypesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_PropertyPropertyListingType_Properties_ListingTypesId",
                        column: x => x.ListingTypesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyPropertyListingType_PropertyListingTypes_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "PropertyListingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListingTypes_CreatedById",
                table: "PropertyListingTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListingTypes_ModifiedById",
                table: "PropertyListingTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListingTypes_Title",
                table: "PropertyListingTypes",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPropertyListingType_PropertiesId",
                table: "PropertyPropertyListingType",
                column: "PropertiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyPropertyListingType");

            migrationBuilder.DropTable(
                name: "PropertyListingTypes");

            migrationBuilder.AddColumn<int>(
                name: "ListingType",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
