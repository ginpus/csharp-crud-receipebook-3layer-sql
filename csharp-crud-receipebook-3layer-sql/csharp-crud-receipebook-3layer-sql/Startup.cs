﻿using Persistence;
using Persistence.Models;
using Persistence.Repositories;
using Domain;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_crud_receipebook_3layer_sql
{
    internal class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            AddSql(services);

            services.AddSingleton<IReceipeRepository, ReceipeRepository>();
            services.AddSingleton<IReceipeService, ReceipeService>();
            services.AddSingleton<ReceipeApp>();

            return services.BuildServiceProvider();
        }

        private IServiceCollection AddSql(IServiceCollection services)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder();

            connectionStringBuilder.Server = "localhost";
            connectionStringBuilder.Port = 3306;
            connectionStringBuilder.UserID = "test";
            connectionStringBuilder.Password = "test";
            connectionStringBuilder.Database = "receipedb";

            var connectionString = connectionStringBuilder.GetConnectionString(true);

            services.AddTransient<ISqlClient>(_ => new SqlClient(connectionString));

            return services;
        }
    }
}