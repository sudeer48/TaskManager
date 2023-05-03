using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;
using System.Text;
using TM.Application.Administration.Implementations;
using TM.Application.Administration.Interfaces;
using TM.Application.EmployeeManagement.Implementations;
using TM.Application.EmployeeManagement.Interfaces;
using TM.Domain.Administration.Implementations;
using TM.Domain.Administration.Interfaces;
using TM.Domain.EmployeeManagement.Implementations;
using TM.Domain.EmployeeManagement.Interfaces;
using TM.Helper.Helper;

namespace WebApplication2
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
            string connString = this.Configuration.GetConnectionString("EmployeeConnection");
            services.AddControllers();

            string corsurl = Configuration.GetValue<string>("ApplicationSettings:CorsUrl");

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigins",
                    builder =>
                    {
                        builder
                            .WithOrigins(corsurl)
                            .AllowCredentials()
                            .AllowAnyHeader()
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyMethod();

                    });
            });
            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddOptions();
            services = LoadAppSettings(services);
            services.AddSwaggerGen();
            services.AddMvc();
           
            services.AddSingleton<IEmployeeManagementApplication, EmployeeManagementApplication>();
            services.AddSingleton<IEmployeeManagementDomain, EmployeeManagementDomain>();
            services.AddSingleton<IAdministrationApplication,AdministrationApplication>();
            services.AddSingleton<IAdministrationDomain, AdministrationDomain>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
        }

        private IServiceCollection LoadAppSettings(IServiceCollection services)
        {
            var appConfig = new ApplicationSettings();
            this.Configuration.Bind("ApplicationSettings", appConfig);
            services.AddSingleton(appConfig);
            return services;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowMyOrigins");
            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
