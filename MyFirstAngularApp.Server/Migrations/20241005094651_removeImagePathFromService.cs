using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstAngularApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class removeImagePathFromService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceImagePath",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceImagePath",
                table: "Services",
                type: "TEXT",
                nullable: true);
        }
    }
}
