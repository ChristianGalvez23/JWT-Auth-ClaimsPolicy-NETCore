using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business;
using business.Context;
using Jose;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<AppDbContext> (options => {
                options.UseSqlServer (Configuration["ConnectionStrings:Default"], b => b.MigrationsAssembly ("api"));
            });

            services.AddAuthentication (config => {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (options => {
                options.Audience = Configuration["Token:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters {
                    RequireExpirationTime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Configuration["Token:Key"]))
                };
            });

            services.AddAuthorization (config => {
                config.AddPolicy ("Users", p => p.RequireClaim ("permission", "cdf79ae2-3262-4d72-b712-ab6bb6b8d1dd"));
                config.AddPolicy ("Admins", p => p.RequireClaim ("permission", "c013272e-251f-42fd-a565-8d24c90502c2"));
            });

            services.AddSingleton<IConfiguration> (provider => Configuration);

            services.AddMvc ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, AppDbContext context) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseAuthentication ();
            context.Database.Migrate ();
            app.UseMvc ();
        }
    }
}