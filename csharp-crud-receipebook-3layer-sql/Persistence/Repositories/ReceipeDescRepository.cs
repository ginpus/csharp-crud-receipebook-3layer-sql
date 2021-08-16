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

        public IEnumerable<ReceipeDescription> GetAll()
        {
            var sqlSelect = $"SELECT * FROM {TableName}";
            return _sqlClient.Query<ReceipeDescription>(sqlSelect);
        }

        public void Save(ReceipeDescription receipe)
        {
            var sqlInsert = @$"INSERT INTO {TableName} (description) VALUES(@description)";
            _sqlClient.Execute(sqlInsert, receipe);
        }

        public void Edit(int id, string description)
        {
            var sqlUpdate = $"UPDATE {TableName} SET description = @description where receipe_id = @receipe_id";

            _sqlClient.Execute(sqlUpdate, new
            {
                receipe_id = id,
                description = description
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