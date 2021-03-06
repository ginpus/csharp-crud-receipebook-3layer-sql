using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IReceipeRepository, ReceipeRepository>();

            return services;
        }

        public static IServiceCollection AddSqlClient(this IServiceCollection services)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder();

            connectionStringBuilder.Server = "localhost";
            connectionStringBuilder.Port = 3306;
            connectionStringBuilder.UserID = "test";
            connectionStringBuilder.Password = "test";
            connectionStringBuilder.Database = "receipedb";

            var connectionString = connectionStringBuilder.GetConnectionString(true);

            return services.AddTransient<ISqlClient>(_ => new SqlClient(connectionString));
        }
    }
}