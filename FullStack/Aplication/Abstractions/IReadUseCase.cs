using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface IReadUseCase<TDTO, TEntity>
    {
        public Task<TDTO> GetByIdAsync(int id);
        public Task<IEnumerable<TDTO>> GetAllAsync();
    }
}
