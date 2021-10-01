using AllMart_WebApi.Common;
using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Repositories;
using AllMart_WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using MediatR;

using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxaFrance.Extensions.DependencyInjection.WebApi;
using System.Reflection;
using AllMart_WebApi.Filters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Bson;

namespace AllMart_WebApi
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
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());
            services.AddSession();
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            Global.ConnectionString = Configuration.GetConnectionString("CustomerDB");
            Global.ConnectionStringPostgreSQL = Configuration.GetConnectionString("CustomerDBCon");

            services.AddSwaggerGen(c =>
            {
                // sepcify our operation filter here.  
                c.OperationFilter<CustomIOperationFilter>();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AllMartApp API",
                    Version = "v1"
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                //c.OperationFilter<CustomHeaderSwaggerAttribute>();
            });
            services.AddHttpClient();
            services.AddWebApi();
            services.AddMvc();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerMongoService, CustomerMongoService>();
            services.AddScoped<ICustomerMongoRepository, CustomerMongoRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IBillsService, BillsService>();
            services.AddScoped<IBillsRepository, BillsRepository>();
            services.AddScoped<ICustomerPostgreSQLService, CustomerPostgreSQLService>();
            services.AddScoped<ICustomerPostgreSQLRepository, CustomerPostgreSQLRepository>();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddMediatR(typeof(CustomerService).Assembly);
            services.AddMediatR(typeof(CustomerRepository).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
            //services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseHttpsRedirection();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AllMartApp API");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
