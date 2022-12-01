using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment CurrentEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();

            services.AddDbContext<ScoutContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DbConnection"]);
            });

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Miami Scouting Reports API", Version = "v1"});
            });

            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment() || Configuration.GetValue<bool>("enableSwaggerUI"))
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