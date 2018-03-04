using IdentitySample.Api.Middlewares;
using IdentitySample.CrossCutting.Identity.Models;
using IdentitySample.Infra.Identity.Data;
using IdentitySample.Infra.IoC.Bootstrappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace IdentitySample.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                  .SetBasePath(env.ContentRootPath)
                                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                                  .AddEnvironmentVariables();

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddMvcOptions(opt => opt.OutputFormatters.RemoveType<XmlDataContractSerializerOutputFormatter>());

            var connectionString = Configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme() {
                    In = "header",
                    Description = "Bearer Token",
                    Name = "Authorization",
                    Type = "apiKey" });
            });

            var auth = Configuration.GetSection("Authentication");

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(opt =>
                {
                    opt.Authority = auth.GetValue<string>("Authority");
                    opt.RequireHttpsMetadata = false;
                    opt.ApiName = auth.GetValue<string>("ApiName");
                });

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestResponseLogging();
            app.UseIdentity();
            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api");
            });

        }
        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            ApiBootstrapper.RegisterServices(services);
        }
    }
}
