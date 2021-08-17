//using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models.ReadModels;

namespace Domain.Services
{
    public interface IReceipeService
    {
        public IEnumerable<Receipe> GetAll(Enum orderField, Enum orderDirection);

        public void Create(ReceipeMain receipe, ReceipeDescription receipeDescription);

        public void Edit(int id, string name, string description);

        public void DeleteById(int id);

        public void ClearAll();

        public void PrintOrderBys();

        public void PrintOrderDirs();

        public void PrintDifficulties();
    }
}