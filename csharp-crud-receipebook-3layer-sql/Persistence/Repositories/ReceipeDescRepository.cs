using Persistence.Models.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReceipeDescRepository : IReceipeDescRepository
    {
        private const string TableName = "receipes_desc";
        private readonly ISqlClient _sqlClient;

        public ReceipeDescRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        public Task<IEnumerable<ReceipeDescription>> GetAllAsync()
        {
            var sqlSelect = $"SELECT * FROM {TableName}";
            return _sqlClient.QueryAsync<ReceipeDescription>(sqlSelect);
        }

        public Task<int> SaveAsync(ReceipeDescription receipe)
        {
            var sqlInsert = @$"INSERT INTO {TableName} (description) VALUES(@description)";
            var rowsAffected = _sqlClient.ExecuteAsync(sqlInsert, receipe);
            return rowsAffected;
        }

        public Task<int> EditAsync(int id, string description)
        {
            var sqlUpdate = $"UPDATE {TableName} SET description = @description where receipe_id = @receipe_id";

            var rowsAffected = _sqlClient.ExecuteAsync(sqlUpdate, new
            {
                receipe_id = id,
                description = description
            });
            return rowsAffected;
        }

        public Task<int> DeleteAsync(int id)
        {
            var sqlDelete = $"DELETE FROM {TableName} WHERE receipe_id = @receipe_id";

            var rowsAffected = _sqlClient.ExecuteAsync(sqlDelete, new
            {
                receipe_id = id
            });
            return rowsAffected;
        }

        public Task<int> DeleteAllAsync()
        {
            var sqlDeleteAll = $"DELETE FROM {TableName}";

            var rowsAffected = _sqlClient.ExecuteAsync(sqlDeleteAll);

            return rowsAffected;
        }
    }
}