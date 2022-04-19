using FluentValidation.AspNetCore;
using LI.Carrinho.API.Filters;
using LI.Carrinho.API.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace LI.Carrinho.API
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
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            services.AddFluentValidation();

            services.AddMvc(options =>
            {
                options.Filters.Add(new DefaultExceptionFilterAttribute());
            });

            services.AddLoggingSerilog();

            services.AddHealthChecks();

            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
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
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/lojaIntegrada-carrinho-api-netcore");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/lojaIntegrada-carrinho-api-netcore/swagger/v1/swagger.json", "API LI.Carrinho.API");
            });

            app.UseHttpsRedirection();

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
