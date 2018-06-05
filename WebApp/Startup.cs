using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.Application.EntityFramework;
using DAL.Application.EntityFramework.Helpers;
using DAL.Application.Interfaces;
using DAL.Identity;
using DAL.Identity.Interfaces;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using WebApp.Services;

namespace WebApp
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
            /*
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                */
            // DI with context pooling
            services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDataContext, ApplicationDbContext>();
            services.AddScoped<IRepositoryProvider, BaseRepositoryProvider<IDataContext>>();
            services.AddSingleton<IRepositoryFactory, BaseRepositoryFactory>();
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();

            services
                .AddScoped<IApplicationUnitOfWork<int, ApplicationUser, Domain.Identity.IdentityRole>,
                    ApplicationUnitOfWork<int, ApplicationUser, Domain.Identity.IdentityRole>>();

            services
                .AddScoped<IUserStore<ApplicationUser>, UserStore<int, ApplicationUser, Domain.Identity.IdentityRole,
                    IdentityUserRole, IdentityUserClaim, IdentityUserLogin, IdentityUserToken,
                    IApplicationUnitOfWork<int, ApplicationUser, Domain.Identity.IdentityRole>>>();

            services
                .AddScoped<IRoleStore<Domain.Identity.IdentityRole>,
                    RoleStore<int, ApplicationUser, Domain.Identity.IdentityRole, IdentityUserRole, IdentityRoleClaim,
                        IApplicationUnitOfWork<int, ApplicationUser, Domain.Identity.IdentityRole>>>();

            services.AddIdentity<ApplicationUser, Domain.Identity.IdentityRole>()
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
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
                //app.UseExceptionHandler("/Home/Error");
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
