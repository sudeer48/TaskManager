using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddAuthentication(
                options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(option => {
                        option.SaveToken = true;
                        option.RequireHttpsMetadata= false;
                        option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidAudience = Configuration["JWT:ValidAudience"],
                            ValidIssuer = Configuration["JWT:ValidIsuser"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT:Secret"))

                        };
                    })
                ;
            services.AddAuthorization();
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
