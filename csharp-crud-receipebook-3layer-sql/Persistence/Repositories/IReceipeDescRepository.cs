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
        Task<IEnumerable<ReceipeDescription>> GetAllAsync();

        Task<int> SaveAsync(ReceipeDescription receipe);

        Task<int> EditAsync(int id, string description);

        Task<int> DeleteAsync(int id);

        Task<int> DeleteAllAsync();
    }
}