using IdentityExample.Data;
using IdentityExample.Middleware;
using IdentityExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace IdentityExample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddIdentity<Student, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 7;
            options.Password.RequireUppercase = true;

            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<StudentContext>();

        builder.Services.AddDbContext<StudentContext>(options =>
              options.UseSqlite("Data Source=student.db"));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseNodeModules(builder.Environment.ContentRootPath);

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Student}/{action=Index}/{id?}");

        app.Run();
    }
}
