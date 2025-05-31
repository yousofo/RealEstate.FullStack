using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PropertyAddedCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CountryId",
                table: "Properties",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Countries_CountryId",
                table: "Properties",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Countries_CountryId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_CountryId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Properties");
        }
    }
}
