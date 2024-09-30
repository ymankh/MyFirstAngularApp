using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstAngularApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed initial data
            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceID", "ServiceName", "ServiceDescription", "ServiceImage" },
                values: new object[,]
                {
                { 1, "Web Development", "Full-stack web development services", "/images/webdev.png" },
                { 2, "Mobile App Development", "Mobile app development services", "/images/mobileapp.png" },
                { 3, "SEO Optimization", "SEO optimization services to improve visibility", "/images/seo.png" }
                });

            migrationBuilder.InsertData(
                table: "subService",
                columns: new[] { "subServiceID", "SubServiceName", "SubServiceDescription", "SubServiceImage", "serviceID" },
                values: new object[,]
                {
                { 1, "Frontend Development", "HTML, CSS, JavaScript, and modern frameworks", "/images/frontend.png", 1 },
                { 2, "Backend Development", "API, databases, and server management", "/images/backend.png", 1 },
                { 3, "iOS Development", "iOS mobile app development services", "/images/ios.png", 2 },
                { 4, "Android Development", "Android mobile app development services", "/images/android.png", 2 },
                { 5, "On-Page SEO", "Optimization of content for search engines", "/images/onpage.png", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the seeded data during rollback
            migrationBuilder.DeleteData(table: "subService", keyColumn: "subServiceID", keyValue: 1);
            migrationBuilder.DeleteData(table: "subService", keyColumn: "subServiceID", keyValue: 2);
            migrationBuilder.DeleteData(table: "subService", keyColumn: "subServiceID", keyValue: 3);
            migrationBuilder.DeleteData(table: "subService", keyColumn: "subServiceID", keyValue: 4);
            migrationBuilder.DeleteData(table: "subService", keyColumn: "subServiceID", keyValue: 5);

            migrationBuilder.DeleteData(table: "Service", keyColumn: "ServiceID", keyValue: 1);
            migrationBuilder.DeleteData(table: "Service", keyColumn: "ServiceID", keyValue: 2);
            migrationBuilder.DeleteData(table: "Service", keyColumn: "ServiceID", keyValue: 3);
        }
    }
}
