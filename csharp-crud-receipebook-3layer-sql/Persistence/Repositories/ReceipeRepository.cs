using Persistence.Models.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReceipeRepository : IReceipeRepository
    {
        private const string TableName = "receipes_main";
        private const string TableName2 = "receipes_desc";
        private readonly ISqlClient _sqlClient;

        public ReceipeRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        public Task<IEnumerable<Receipe>> GetAllAsync(Enum orderField, Enum orderDirection)
        {
            var sqlSelect = $"SELECT {TableName}.receipe_id, {TableName}.name, {TableName}.difficulty, {TableName}.time_to_complete, {TableName}.date_created, {TableName2}.description FROM {TableName} JOIN {TableName2} ON {TableName}.receipe_id = {TableName2}.receipe_id ORDER BY {orderField.ToString()} {orderDirection.ToString()}";

            return _sqlClient.QueryAsync<Receipe>(sqlSelect);
        }

        public Task<int> SaveAsync(ReceipeMain receipe)
        {
            var sqlInsert = @$"INSERT INTO {TableName} (name, difficulty, time_to_complete, date_created) VALUES(@name, @difficulty, @time_to_complete, @date_created)";
            var rowsAffected = _sqlClient.ExecuteAsync(sqlInsert, new
            {
                name = receipe.Name,
                difficulty = receipe.Difficulty.ToString(),
                time_to_complete = receipe.Time_To_Complete,
                date_created = receipe.Date_Created
            });
            return rowsAffected;
        }

        public Task<int> EditAsync(int id, string name)
        {
            var sqlUpdate = $"UPDATE {TableName} SET name = @name where receipe_id = @receipe_id";

            var rowsAffected = _sqlClient.ExecuteAsync(sqlUpdate, new
            {
                receipe_id = id,
                name = name
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