using Hospital.Models;
using Hospital.Repos.implementation;
using Hospital.Repos.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IDoctor, DoctorRepo>();
            builder.Services.AddScoped<IPatient, patientrepo>();
            builder.Services.AddScoped<IAppointment, appointmentrepo>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Appdbcontext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("conc")));
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

            app.Run();
        }
    }
}
