﻿using Customer.Application.Contracts.Infrastructure;
using Customer.Application.Contracts.Persistence;
using Customer.Infrastructure.Persistence;
using Customer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MSSqlConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped(sp => new HttpClient());
            services.AddScoped<ICustomValidator, CustomValidator>();

            return services;
        }
    }
}
