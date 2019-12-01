using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Services;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Api.FileStorage;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CleanArchitecture.Web
{
	public class Startup
	{
		public Startup(IConfiguration config) => this.Configuration = config;

		public IConfiguration Configuration { get; }

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			
            services.AddIdentityDbContext();
            services.AddDefaultIdentity<ApplicationUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 7;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAppDbContext();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped(typeof(IMissionImageUploader), typeof(MissionImageUploader));

            services.AddScoped(typeof(IMissionListViewModelService), typeof(MissionListViewModelService));
            services.AddScoped(typeof(IMissionDetailedViewModelService), typeof(MissionDetailedViewModelService));
            services.AddScoped(typeof(IMissionNoteViewModelService), typeof(MissionNoteViewModelService));
            services.AddScoped(typeof(IMissionViewModelService), typeof(MissionViewModelService));
            services.AddScoped(typeof(IEmployerViewModelService), typeof(EmployerViewModelService));
            services.AddScoped(typeof(IUserViewModelService), typeof(UserViewModelService));        

            services.AddSingleton<IBlobStorageService, AzureBlobStorageService>();

            //services.Configure<HtmlHelperOptions>(o => o.ClientValidationEnabled = true);

            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                   
                });

            return ContainerSetup.InitializeWeb(Assembly.GetExecutingAssembly(), services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.EnvironmentName == "Development")
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
       
                endpoints.MapRazorPages();
            });
        }

    }
}
