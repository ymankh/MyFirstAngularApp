using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstAngularApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class createSubsecriptionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubServiceID = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Plan = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionID);
                    table.ForeignKey(
                        name: "FK_Subscriptions_CustomUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "CustomUsers",
                        principalColumn: "CustomUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubServices_SubServiceID",
                        column: x => x.SubServiceID,
                        principalTable: "SubServices",
                        principalColumn: "SubServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomUserId",
                table: "Subscriptions",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubServiceID",
                table: "Subscriptions",
                column: "SubServiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
