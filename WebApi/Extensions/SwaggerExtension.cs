using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebApi.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi", Version = "v1"});

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "JWT Authentication using Bearer scheme",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new string[] { }
                    }
                });
            });
            return services;
        }
    }
}
