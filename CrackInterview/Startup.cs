﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrackInterview.DataAccess;
using CrackInterview.Utility.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;



namespace CrackInterview
{
    public class Startup
    {
        /// <summary>
        /// Interface for Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor for Startup
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            #region DataAccess
            services.AddTransient<IDatabaseAccess, DatabaseAccess>();
            services.AddSingleton<IConfiguration>(Configuration);
            

            #endregion DataAccess

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region API Versioning with Swagger

            services.AddApiVersionWithExplorer().AddSwaggerOptions().AddSwaggerGen();
            services.Configure<SwaggerSettings>(Configuration.GetSection(nameof(SwaggerSettings)));

            #endregion API Versioning with Swagger
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerJsonPath = Configuration.GetSection("ApplicationOptions").GetSection("SwaggerJsonPath").Value;
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    //Build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        var swaggerUrl = string.Format(swaggerJsonPath, description.GroupName);
                        var swaggerVersion = description.GroupName.ToUpperInvariant();
                        Log.Information("Swagger Json Path : " + swaggerVersion + " - " + swaggerUrl);
                        options.SwaggerEndpoint(swaggerUrl, "CrackInterview.WISE.AIGSS - " + swaggerVersion);
                    }
                });
            app.UseSwaggerDocuments();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "application/yaml",
            });

            app.UseMvc();

        }
    }
}
