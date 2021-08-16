﻿using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class SqlClient : ISqlClient
    {
        private readonly string _connectionString;

        public SqlClient(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Execute(string sql, object param = null) // sql's will come from Repositories
        {
            using var connection = new MySqlConnection(_connectionString);

            connection.Open();

            return connection.Execute(sql, param);
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using var connection = new MySqlConnection(_connectionString);

            connection.Open();

            return connection.Query<T>(sql, param);
        }

        /*        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
                {
                    using var connection = new MySqlConnection(_connectionString);

                    connection.Open();

                    var result = await connection.QueryAsync<T>(sql, param); // async method should return type

                    return result;
                }*/
    }
}