// <copyright file="Startup.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API
{
    using System.Reflection;
    using API.Data;
    using API.Data.Repository;
    using API.Data.Repository.Interfaces;
    using API.Services;
    using API.Services.Interfaces;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// This is the startup class where all the dependencies are being injected.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The current application configuration settings.</param>
        /// <param name="env">The web hosting environment that contains this application.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Configuration = configuration;
            this.CurrentEnvironment = env;
        }

        /// <summary>
        /// Gets all of the configuration values.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the current environment for the application.
        /// </summary>
        public IWebHostEnvironment CurrentEnvironment { get; }

        /// <summary>
        /// This method will configure all of the dependencies accordingly.
        /// </summary>
        /// <param name="services">The list of services/dependencies that are required.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();

            services.AddDbContext<ScoutContext>(options =>
            {
                options.UseSqlServer(this.Configuration["ConnectionStrings:DbConnection"]);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Miami Scouting Reports API",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Email = "pkrish19@outlook.com",
                            Name = "Pranav Krishnamurthy",
                        },
                    });
            });

            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddHealthChecks();
            services.AddApplicationInsightsTelemetry();

            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IScoutingReportRepository, ScoutingReportRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITeamPlayerRepository, TeamPlayerRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();

            services.AddTransient<ITeamsService, TeamsService>();
            services.AddTransient<IScoutingReportService, ScoutingReportService>();
            services.AddTransient<ITeamPlayerService, TeamPlayerService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILeagueService, LeagueService>();
        }

        /// <summary>
        /// This method will configure the application to run within the web hosting environment.
        /// </summary>
        /// <param name="app">The application builder middleware.</param>
        /// <param name="env">The current web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment() || this.Configuration.GetValue<bool>("enableSwaggerUI"))
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scouting Reports API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}