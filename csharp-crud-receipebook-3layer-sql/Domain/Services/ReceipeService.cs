//using Domain.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models.ReadModels;

namespace Domain.Services
{
    public class ReceipeService : IReceipeService
    {
        private readonly IReceipeRepository _receipeRepository;
        private readonly IReceipeDescRepository _receipeDescRepository;

        public ReceipeService(IReceipeRepository receipeRepository, IReceipeDescRepository receipeDescRepository)
        {
            _receipeRepository = receipeRepository;
            _receipeDescRepository = receipeDescRepository;
        }

        public IEnumerable<Receipe> GetAll()
        {
            return _receipeRepository.GetAll();
        }

        public void Create(ReceipeMain receipe, ReceipeDescription receipeDescription)
        {
            _receipeRepository.Save(receipe);
            _receipeDescRepository.Save(receipeDescription);
        }

        public void Edit(int id, string name, string description)
        {
            _receipeRepository.Edit(id, name);
            _receipeDescRepository.Edit(id, description);
        }

        public void DeleteById(int id)
        {
            _receipeRepository.Delete(id);
            _receipeDescRepository.Delete(id);
        }

        public void ClearAll()
        {
            _receipeRepository.DeleteAll();
            _receipeDescRepository.DeleteAll();
        }
    }
}