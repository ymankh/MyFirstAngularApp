using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstAngularApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class addImagesToServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubServiceImagePath",
                table: "SubServices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceImagePath",
                table: "Services",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubServiceImagePath",
                table: "SubServices");

            migrationBuilder.DropColumn(
                name: "ServiceImagePath",
                table: "Services");
        }
    }
}
