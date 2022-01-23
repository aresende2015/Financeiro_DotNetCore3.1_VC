using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Investimento.Data.Context;
using Investimento.Data.Repositories;
using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;
using Investimento.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Investimento.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InvestimentoContext>(
                context => context.UseSqlite(_configuration.GetConnectionString("Default"))
            );

            services.AddControllers()
                .AddNewtonsoftJson(
                    opt => opt.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IClasseDeAtivoRepo, ClasseDeAtivoRepo>();
            services.AddScoped<IAtivoRepo, AtivoRepo>();
            services.AddScoped<IClienteRepo, ClienteRepo>();

            services.AddScoped<IGeralRepo, GeralRepo>();

            services.AddScoped<IClasseDeAtivoService, ClasseDeAtivoService>();
            services.AddScoped<IAtivoService, AtivoService>();
            services.AddScoped<IClienteService, ClienteService>();
                    
             services.AddSwaggerGen(options =>
             {
                options.SwaggerDoc(
                     "v1", 
                     new OpenApiInfo 
                        { 
                            Title = "Investimento API", 
                            Version = "1.0" 
                        }
                );

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                options.IncludeXmlComments(xmlCommentsFilePath);
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Investimento.API v1");
                    options.RoutePrefix = "";
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
