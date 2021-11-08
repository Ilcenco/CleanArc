using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application;
using Microsoft.OpenApi.Models;
using CleanArc.Persistance;
using CleanArc.Persistance.Context;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Application.Common.Interfaces;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using FluentValidation;
using CleanArc.Application.Services.Projects.Commands.UpdateProject;

namespace Web
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
            //services.AddTransient<IValidator<ProjectUpdateViewModel>, ProjectUpdateViewModelValidator>();

            services.AddPersistence(Configuration);
            services.AddApplication();

            //services.AddControllers().AddFluentValidation( fv => {

            //    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            //    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            //});
            services.AddMvc(options =>
            {
                //options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
            })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IDataContext>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiLayer", Version = "v1" });
            });

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 5;

            })
                .AddRoles<IdentityRole>()

                .AddEntityFrameworkStores<DataContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiLayer v1"));
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
