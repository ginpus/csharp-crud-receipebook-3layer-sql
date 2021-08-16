using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models.ReadModels;

namespace Persistence.Repositories
{
    public interface IReceipeDescRepository
    {
        IEnumerable<ReceipeDescription> GetAll();

        void Save(ReceipeDescription receipe);

        void Edit(int id, string description);

        void Delete(int id);

        void DeleteAll();
    }
}