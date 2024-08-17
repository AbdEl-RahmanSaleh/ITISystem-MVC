using ITISystem.Models.Context;
using ITISystem.Service;
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


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
