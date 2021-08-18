using Domain.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models.ReadModels;
using Contracts.Enums;

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

        public async Task<IEnumerable<ReceipeDomain>> GetAllAsync(Enum orderField, Enum orderDirection)
        {
            var receipes = await _receipeRepository.GetAllAsync(orderField, orderDirection); //await is needed as we do the remaping of model
            return receipes.Select(receipe => new ReceipeDomain
            {
                Receipe_Id = receipe.Receipe_Id,
                Name = receipe.Name,
                Description = receipe.Description,
                Difficulty = receipe.Difficulty,
                Time_To_Complete = receipe.Time_To_Complete,
                Date_Created = receipe.Date_Created
            });
        }

        public async Task<int> CreateAsync(ReceipeMain receipe, ReceipeDescription receipeDescription)
        {
            var mainCreate = _receipeRepository.SaveAsync(receipe);
            var descCreate = _receipeDescRepository.SaveAsync(receipeDescription);

            await Task.WhenAll(mainCreate, descCreate);

            return await mainCreate;
        }

        public async Task<int> EditAsync(int id, string name, string description)
        {
            var mainEdit = _receipeRepository.EditAsync(id, name);
            var descEdit = _receipeDescRepository.EditAsync(id, description);

            await Task.WhenAll(mainEdit, descEdit);

            return await mainEdit;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var mainDelete = _receipeRepository.DeleteAsync(id);
            var descDelete = _receipeDescRepository.DeleteAsync(id);

            await Task.WhenAll(mainDelete, descDelete);

            return await descDelete;
        }

        public async Task<int> ClearAllAsync()
        {
            var mainDeleteAll = _receipeRepository.DeleteAllAsync();
            var descDeleteAll = _receipeDescRepository.DeleteAllAsync();

            await Task.WhenAll(mainDeleteAll, descDeleteAll);

            return await mainDeleteAll;
        }

        public void PrintOrderBys()
        {
            var count = 0;
            foreach (var name in Enum.GetNames(typeof(OrderBy)))
            {
                Console.WriteLine($"{++count} - {name}");
            }
        }

        public void PrintOrderDirs()
        {
            var count = 0;
            foreach (var name in Enum.GetNames(typeof(OrderDirection)))
            {
                Console.WriteLine($"{++count} - {name}");
            }
        }

        public void PrintDifficulties()
        {
            var count = 0;
            foreach (var name in Enum.GetNames(typeof(Difficulty)))
            {
                Console.WriteLine($"{++count} - {name}");
            }
        }
    }
}