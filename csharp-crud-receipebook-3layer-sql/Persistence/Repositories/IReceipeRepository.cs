using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IReceipeRepository
    {
        IEnumerable<Receipe> GetAll();

        void Save(Receipe receipe);

        void Edit(int id, string name, string description);

        void Delete(int id);

        void DeleteAll();
    }
}