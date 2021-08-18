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
        Task<IEnumerable<Receipe>> GetAllAsync(Enum orderField, Enum orderDirection);

        Task<int> SaveAsync(ReceipeMain receipe);

        Task<int> EditAsync(int id, string name);

        Task<int> DeleteAsync(int id);

        Task<int> DeleteAllAsync();
    }
}