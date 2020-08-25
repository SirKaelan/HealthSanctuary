using FluentValidation.AspNetCore;
using HealthSanctuary.Core.Models;
using HealthSanctuary.Core.Repositories;
using HealthSanctuary.Core.Services.Exercises;
using HealthSanctuary.Core.Services.Workouts;
using HealthSanctuary.Data.Context;
using HealthSanctuary.Data.Repositories;
using HealthSanctuary.Web.Mappers.Exercises;
using HealthSanctuary.Web.Mappers.WorkoutExercises;
using HealthSanctuary.Web.Mappers.Workouts;
using HealthSanctuary.Web.Validators.Workouts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthSanctuary.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AddAuth(services);
            AddDbContext(services);
            AddRepositories(services);
            AddMappers(services);
            AddServices(services);

            services
                .AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<WorkoutRequestValidator>());
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<HealthSanctuaryContext>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IWorkoutsRepository, WorkoutsRepository>();
            services.AddTransient<IExercisesRepository, ExercisesRepository>();
        }

        private void AddMappers(IServiceCollection services)
        {
            services.AddTransient<IWorkoutMapper, WorkoutMapper>();
            services.AddTransient<IWorkoutExerciseMapper, WorkoutExerciseMapper>();
            services.AddTransient<IExerciseMapper, ExerciseMapper>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<IWorkoutService, WorkoutService>();
            services.AddTransient<IExerciseService, ExerciseService>();
        }

        private void AddAuth(IServiceCollection services)
        {
            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<HealthSanctuaryContext>();

            services
                .AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, HealthSanctuaryContext>();

            services
                .AddAuthentication()
                .AddIdentityServerJwt();
        }
    }
}
