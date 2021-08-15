using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IReceipeService
    {
        public IEnumerable<Receipe> GetAll();

        public void Create(Receipe receipe);

        public void Edit(int id, string name, string description);

        public void DeleteById(int id);

        public void ClearAll();
    }
}