using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReceipeRepository : IReceipeRepository
    {
        private const string TableName = "receipes";
        private readonly ISqlClient _sqlClient;

        public ReceipeRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        public IEnumerable<Receipe> GetAll()
        {
            var sqlSelect = $"SELECT * FROM {TableName}";
            return _sqlClient.Query<Receipe>(sqlSelect);
        }

        public void Save(Receipe receipe)
        {
            var sqlInsert = @$"INSERT INTO {TableName} (name, description, difficulty, time_to_complete, date_created) VALUES(@name, @description, @difficulty, @time_to_complete, @date_created)";
            _sqlClient.Execute(sqlInsert, receipe);
        }

        public void Edit(int id, string name, string description)
        {
            var sqlUpdate = $"UPDATE {TableName} SET name = @name, description = @description where receipe_id = @receipe_id";

            _sqlClient.Execute(sqlUpdate, new
            {
                receipe_id = id,
                name = name,
                description = description,
                date_created = DateTime.Now
            });
        }

        public void Delete(int id)
        {
            var sqlDelete = $"DELETE FROM {TableName} WHERE receipe_id = @receipe_id";

            _sqlClient.Execute(sqlDelete, new
            {
                receipe_id = id
            });
        }

        public void DeleteAll()
        {
            var sqlDeleteAll = $"DELETE FROM {TableName}";

            _sqlClient.Execute(sqlDeleteAll);
        }
    }
}