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

        public IEnumerable<Receipe> GetAll(Enum orderField, Enum orderDirection)
        {
            //var sqlSelect = $"SELECT {TableName}.receipe_id, {TableName}.name, {TableName}.difficulty, {TableName}.time_to_complete, {TableName}.date_created, {TableName2}.description FROM {TableName} JOIN {TableName2} ON {TableName}.receipe_id = {TableName2}.receipe_id ORDER BY @orderFld @orderDir";

            var sqlSelect = $"SELECT {TableName}.receipe_id, {TableName}.name, {TableName}.difficulty, {TableName}.time_to_complete, {TableName}.date_created, {TableName2}.description FROM {TableName} JOIN {TableName2} ON {TableName}.receipe_id = {TableName2}.receipe_id ORDER BY {orderField.ToString()} {orderDirection.ToString()}";

            return _sqlClient.Query<Receipe>(sqlSelect);

            /*            return _sqlClient.Query<Receipe>(sqlSelect, new {
                            orderFld = orderField.ToString(),
                            orderDir = orderDirection.ToString(),
                        });*/
        }

        public void Save(ReceipeMain receipe)
        {
            var sqlInsert = @$"INSERT INTO {TableName} (name, difficulty, time_to_complete, date_created) VALUES(@name, @difficulty, @time_to_complete, @date_created)";
            _sqlClient.Execute(sqlInsert, new
            {
                name = receipe.Name,
                difficulty = receipe.Difficulty.ToString(),
                time_to_complete = receipe.Time_To_Complete,
                date_created = receipe.Date_Created
            });
        }

        public void Edit(int id, string name)
        {
            var sqlUpdate = $"UPDATE {TableName} SET name = @name where receipe_id = @receipe_id";

            _sqlClient.Execute(sqlUpdate, new
            {
                receipe_id = id,
                name = name
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