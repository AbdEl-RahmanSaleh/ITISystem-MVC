using ITISystem.Models.Context;
using ITISystem.Service;
using ITISystem.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace ITISystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<IDepartmentService, DepartmentService2>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddDbContext<ITIContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(2);
            });



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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Role}/{action=Index}/{id?}");


            #region Middleware Lab

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("M1 : Welcome From M1\n");
            //    await next();
            //    await context.Response.WriteAsync("M1 : Welcome After Return From M2\n");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("M2 : Welcome From M2\n");
            //}); 
            #endregion


            app.Run();
        }
    }
}
