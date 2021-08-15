using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ReceipeService : IReceipeService
    {
        private readonly IReceipeRepository _receipeRepository;

        public ReceipeService(IReceipeRepository receipeRepository)
        {
            _receipeRepository = receipeRepository;
        }

        public IEnumerable<Receipe> GetAll()
        {
            return _receipeRepository.GetAll();
        }

        public void Create(Receipe receipe)
        {
            _receipeRepository.Save(receipe);
        }

        public void Edit(int id, string name, string description)
        {
            _receipeRepository.Edit(id, name, description);
        }

        public void DeleteById(int id)
        {
            _receipeRepository.Delete(id);
        }

        public void ClearAll()
        {
            _receipeRepository.DeleteAll();
        }
    }
}