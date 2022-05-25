using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MWNZ.Evaluation.Integration;
using MWNZ.Evaluation.Integration.Clients;
using MWNZ.Evaluation.Integration.Interface;
using MWNZ.Evaluation.Services;
using MWNZ.Evaluation.Services.Interface;
using Swashbuckle.AspNetCore.Filters;

namespace MWNZ.Evaluation
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MWNZ.Evaluation", Version = "v1" });
                c.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();

            services.AddHttpClient();

            // configuration options
            services.Configure<ServerOptions>(Configuration.GetSection("ServerOptions"));

            // services
            services.AddTransient<IMWNZCompaniesService, MWNZCompaniesService>();

            // integration
            services.AddTransient<IMWNZCompaniesClient, MWNZCompaniesClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MWNZ.Evaluation v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
