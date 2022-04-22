using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace LI.Carrinho.API.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LI.Carrinho.API",
                    Description = "Desafio Loja Integrada",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "LI.Carrinho.API.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "LI.Carrinho.Application.xml");

                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(applicationPath);

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Auth Header"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                               Type = ReferenceType.SecurityScheme,
                               Id = "basic"
                            }
                        },
                        new string[]{ }
                    }
                });
            });

            return services;
        }
    }
}
