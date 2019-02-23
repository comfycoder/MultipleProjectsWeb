using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Data.Models;
using MyApp.Services;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;

namespace MyApp.Web
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            services.AddScoped<ICustomerService, CustomerService>();

            // https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio
            var connection = Configuration["ConnectionString"];

            services.AddDbContext<AdventureWorksDbContext>
                (options => options.UseSqlServer(connection));

            services.AddAutoMapper();

            // https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters#advanced-examples-with-dependency-injection
            services.AddSwaggerExamples();

            // https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters#automatic-annotation
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=netcore-cli
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Customers API",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new Contact
                    {
                        Name = "Dennis Moon",
                        Email = string.Empty,
                        Url = "https://dennismoon.com"
                    }
                });

                c.ExampleFilters();

                // Set the comments path for the Swagger JSON and UI.
                // https://github.com/domaindrivendev/Swashbuckle/issues/93
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            // https://github.com/domaindrivendev/Swashbuckle.AspNetCore
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Customers API V1");
                c.RoutePrefix = string.Empty;
                c.DisplayOperationId();
                c.ShowExtensions();
            });

            app.UseMvc();
        }
    }
}
