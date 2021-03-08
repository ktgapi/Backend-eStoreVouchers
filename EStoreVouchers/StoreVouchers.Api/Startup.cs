namespace StoreVouchers.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SaaSVP.Authentication.Data;
    using SaaSVP.Authentication.Entities;
    using StoreVouchers.Api.Entities;
    using StoreVouchers.Api.Extensions.Injection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //// Through Extension Methods, call Service Injections here.
            services.InjectAttributes();
            services.InjectInfrastructure(this.Configuration);
            services.InjectOrderService(this.Configuration);

            var databaseConfig = this.Configuration.GetSection("Database");

            services.AddDbContext<ApplicationDbContext<UserEntity>>(options =>
                options.UseSqlServer(databaseConfig["ConnectionString"]));

            services.AddIdentity<UserEntity, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext<UserEntity>>()
                .AddDefaultTokenProviders();

            services.AddApplicationInsightsTelemetry(this.Configuration.GetSection("ApplicationInsights")["InstrumentationKey"]);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            var origins = this.Configuration.GetSection("AllowedOrigins").Get<string[]>();

            app.UseCors(x => x
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
