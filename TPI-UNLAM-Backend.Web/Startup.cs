using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;
using TIP_UNLAM_Backend.Data;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;
using TPI_UNLAM_Backend.Exceptions;
using TPI_UNLAM_Backend.Servicios;
using TPI_UNLAM_Backend.Servicios.Interfaces;


namespace TPI_UNLAM_Backend
{
    public class Startup
    {
        private readonly string _myCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor(); //Para poder acceder al contexto dentro de una clase

            services.AddControllers();
            services.AddTransient<TPI_UNLAM_DB_Context>();
            services.AddScoped<IJuegoServicio, JuegoServicio>();
            services.AddScoped<IJuegoRepositorio, JuegoRepositorio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioXUsuarioServicio, UsuarioXUsuarioServicio>();
            services.AddScoped<IUsuarioXUsuarioRepositorio, UsuarioXUsuarioRepositorio>();
            services.AddScoped<IProgresosXUsuarioXJuegoRepositorio, ProgresosXUsuarioXJuegoRepositorio>();
            services.AddScoped<IProgresosXUsuarioXJuegoServicio, ProgresosXUsuarioXJuegoServicio>();

            services.AddSingleton<IAppSharedFunction, AppSharedFunction>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                ClockSkew = TimeSpan.Zero
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TPI_UNLAM_Backend", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Token usar Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }});
            });

            //agrego servicio de CORS
            services.AddCors(options =>
            {
                options.AddPolicy(_myCors, builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddMvc(config =>
            {
                config.Filters.Add(new HttpResponseExceptionFilter());
                config.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TPI_UNLAM_Backend v1"));
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //agrego servicio de CORS
            app.UseCors(_myCors);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
        {
            public void Apply(ControllerModel controller)
            {
                // Ejemplo: "Controllers.v1"
                var controllerNamespace = controller.ControllerType.Namespace;
                var apiVersion = controllerNamespace.Split('.').Last().ToLower();
                controller.ApiExplorer.GroupName = apiVersion;
            }
        }
    }
}
