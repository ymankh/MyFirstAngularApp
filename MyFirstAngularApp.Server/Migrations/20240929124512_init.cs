using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstAngularApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ServiceDescription = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ServiceImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "SubServices",
                columns: table => new
                {
                    SubServiceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubServiceName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SubServiceDescription = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    SubServiceImage = table.Column<string>(type: "TEXT", nullable: false),
                    ServiceID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubServices", x => x.SubServiceID);
                    table.ForeignKey(
                        name: "FK_SubServices_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubServices_ServiceID",
                table: "SubServices",
                column: "ServiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubServices");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
