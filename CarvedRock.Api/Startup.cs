﻿using CarvedRock.Api.Data;
using CarvedRock.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarvedRock.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<CarvedRockDbContext>(options => {
                options.UseSqlServer(_config["ConnectionStrings:CarvedRock"]);
                options.EnableDetailedErrors();
            });
            services.AddSingleton<ProductRepository>();
        }

        public void Configure(IApplicationBuilder app, CarvedRockDbContext dbContext)
        {
            app.UseMvc();
            dbContext.Database.EnsureCreated();
            dbContext.Seed();
        }
    }
}