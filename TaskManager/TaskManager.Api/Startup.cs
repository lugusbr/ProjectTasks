using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManager.Api.Model.Context;
using System;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Hosting;
using TaskManager.Api.Repository.Generic;
using TaskManager.Api.Business;
using TaskManager.Api.Business.Implementation;
using TaskManager.Api.Repository;
using TaskManager.Api.Repository.Implementation;

namespace TaskManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }
        public object SwaggerConfig { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddCors();
            services.AddControllers();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, serverVersion));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Api Task manager",
                        Version = "v1"
                    });
 
            });

            services.AddScoped<ITaskTypeBusiness, TaskTypeBusiness>();

            services.AddScoped<ITaskBusiness, TaskBusiness>();
            services.AddScoped<ITaskTimeBusiness, TaskTimeBusiness>();

            services.AddScoped<ITaskTypeRepository, TaskTypeRepository>();

            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddScoped<ITaskTimeRepository, TaskTimeRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
