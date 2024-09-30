using Microsoft.EntityFrameworkCore;
using MyFirstAngularApp.Server.Models;

namespace MyFirstAngularApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // CORS configuration to allow any origin, method, and header
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    corsPolicyBuilder =>
                    {
                        corsPolicyBuilder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure SQLite database
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // Use proxy to the Angular development server in development mode
                //app.UseSpa(spa =>
                //{
                //    spa.Options.SourcePath = "ClientApp"; // Path to Angular project

                //    // Proxy to Angular dev server
                //    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // Adjust the port for Angular dev server
                //});
            }

            app.UseHttpsRedirection();

            // Enable CORS globally
            app.UseCors("AllowAnyOrigin");

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
