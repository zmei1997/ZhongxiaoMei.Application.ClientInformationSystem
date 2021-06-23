using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.OpenApi.Models;

namespace ClientInformationSystem.API
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
            // create the connection to ClientInformationSystem database
            services.AddDbContext<ClientInformationSystemDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ClientInformationSystemDbConnection"));
            });

            services.AddControllers();

            // Dependency injection
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IClientsService, ClientsService>();

            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IEmployeesService, EmployeesService>();

            services.AddScoped<IInteractionsRepository, InteractionsRepository>();
            services.AddScoped<IInteractionsService, InteractionsService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientInformationSystem.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientInformationSystem.API v1"));
            }

            // CORS middleware
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("angularSPAClientUrl")).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
