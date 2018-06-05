using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Application.EFString;
using DAL.Application.EntityFramework;
using DAL.Application.EntityFramework.Helpers;
using DAL.Application.Interfaces;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;
using Domain.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppString.Services;

namespace WebAppString
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
            services.AddDbContextPool<ApplicationDbContextString>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDataContext, ApplicationDbContextString>();
            services.AddScoped<IRepositoryProvider, BaseRepositoryProvider<IDataContext>>();
            services.AddSingleton<IRepositoryFactory, BaseRepositoryFactory>();

            //services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();

            services.AddScoped<IApplicationUnitOfWorkStr, ApplicationUnitOfWorkStr>();

            services
                .AddScoped<IApplicationUnitOfWork<string, IdentityUserStr, Domain.Identity.IdentityRoleStr>,
                    ApplicationUnitOfWork<string, IdentityUserStr, Domain.Identity.IdentityRoleStr>>();

            services
                .AddScoped<IUserStore<IdentityUserStr>, UserStore<string, IdentityUserStr, Domain.Identity.IdentityRoleStr,
                    IdentityUserRoleStr, IdentityUserClaimStr, IdentityUserLoginStr, IdentityUserTokenStr,
                    IApplicationUnitOfWork<string, IdentityUserStr, Domain.Identity.IdentityRoleStr>>>();

            services
                .AddScoped<IRoleStore<Domain.Identity.IdentityRoleStr>,
                    RoleStore<string, IdentityUserStr, Domain.Identity.IdentityRoleStr, IdentityUserRoleStr, IdentityRoleClaimStr,
                        IApplicationUnitOfWork<string, IdentityUserStr, Domain.Identity.IdentityRoleStr>>>();

            services.AddIdentity<IdentityUserStr, Domain.Identity.IdentityRoleStr>()
                .AddDefaultTokenProviders();



            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "arearoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
