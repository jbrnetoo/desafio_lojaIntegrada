using AutoMapper;
using FluentValidation.AspNetCore;
using LI.Carrinho.API.Filters;
using LI.Carrinho.API.Logging;
using LI.Carrinho.CrossCutting.Assemblies;
using LI.Carrinho.CrossCutting.IoC;
using LI.Carrinho.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddFluentValidation();

            services.AddDependencyResolver();

            services.AddMvc(options =>
            {
                options.Filters.Add(new DefaultExceptionFilterAttribute());
            });

            services.AddLoggingSerilog();

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            services.AddDbContext<CarrinhoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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
