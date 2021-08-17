using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models.ReadModels;

namespace Persistence.Repositories
{
    public interface IReceipeRepository
    {
        IEnumerable<Receipe> GetAll(Enum orderField, Enum orderDirection);

        void Save(ReceipeMain receipe);

        void Edit(int id, string name);

        void Delete(int id);

        void DeleteAll();
    }
}