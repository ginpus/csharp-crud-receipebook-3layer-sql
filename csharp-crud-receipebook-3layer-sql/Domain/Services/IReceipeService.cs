using Domain.Models;
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
        Task<IEnumerable<ReceipeDomain>> GetAllAsync(Enum orderField, Enum orderDirection);

        Task<int> CreateAsync(ReceipeMain receipe, ReceipeDescription receipeDescription);

        Task<int> EditAsync(int id, string name, string description);

        Task<int> DeleteByIdAsync(int id);

        Task<int> ClearAllAsync();

        void PrintOrderBys();

        void PrintOrderDirs();

        void PrintDifficulties();
    }
}