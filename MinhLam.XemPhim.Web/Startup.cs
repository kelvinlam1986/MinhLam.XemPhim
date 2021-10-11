using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinhLam.Framework;
using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Application.Admin.Query;
using MinhLam.XemPhim.Application.Web.Query;
using MinhLam.XemPhim.Domain;
using MinhLam.XemPhim.Domain.Repositories;
using MinhLam.XemPhim.Infrastructure;
using MinhLam.XemPhim.Infrastructure.Admin;
using MinhLam.XemPhim.Infrastructure.Domains;
using MinhLam.XemPhim.Infrastructure.Repositories;
using MinhLam.XemPhim.Infrastructure.Services;
using MinhLam.XemPhim.Infrastructure.Utilities;
using MinhLam.XemPhim.Infrastructure.Web.Query;
using MinhLam.XemPhim.Web.Middlewares;
using System;

namespace MinhLam.XemPhim.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("connection"), 
                b => b.MigrationsAssembly("MinhLam.XemPhim.Web")));
            services.AddSession();
           
            services.AddControllersWithViews();
            services.AddScoped<IHomePageMenuQuery, HomePageMenuQuery>();
            services.AddScoped<IHomePageQuery, HomePageQuery>();
            services.AddScoped<IAccountQuery, AccountQuery>();
            services.AddScoped<IUserRolesQuery, UserRolesQuery>();
            services.AddScoped<IUserQuery, UserQuery>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICheckExisting, CheckExisting>();
            services.AddScoped<IGetData, GetData>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            // app.UseAuthentication();
            app.UseRequestCulture();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
