using System.Collections.Generic;
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
using HealthSanctuary.Web.Middleware;
using HealthSanctuary.Web.Validators.Workouts;
using IdentityServer4.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;

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

            services.AddSwaggerGen();
            services.AddOData();

            services
                .AddControllersWithViews(o => o.Filters.Add(new AuthorizeFilter("ApiScope")))
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthSancuary V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Select().Expand().Count().Filter().OrderBy().MaxTop(100).SkipToken();
                endpoints.MapODataRoute("workouts", "api", GetEdmModel());
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
                .AddApiAuthorization<ApplicationUser, HealthSanctuaryContext>()
                .AddInMemoryApiResources(new List<ApiResource>
                {
                    new ApiResource("hsApi")
                    {
                        UserClaims = new List<string> { "admin" }
                    }
                })
                .AddInMemoryClients(new List<Client>
                {
                    new Client
                    {
                        ClientId = "ro.client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        AllowedScopes = new List<string> { "hsApi", "openid", "profile" },
                        RequireClientSecret = false,
                        AllowOfflineAccess = true,
                    }
                });

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerJwt()
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "hsApi");
                    policy.AuthenticationSchemes = new List<string> { "Bearer" };
                });

                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("admin", "admin");
                    policy.RequireClaim("scope", "hsApi");
                    policy.AuthenticationSchemes = new List<string> { "Bearer" };
                });
            });
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Workout>("Workouts");
            builder.EntitySet<WorkoutExercise>("WorkoutExercises").EntityType.HasKey(x => new { x.WorkoutId, x.ExerciseId });
            builder.EntitySet<Exercise>("Exercises");
            return builder.GetEdmModel();
        }
    }
}
