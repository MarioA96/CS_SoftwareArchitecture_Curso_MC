using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface IReadRepository<TEntity>
    {
        public Task<TEntity> GetByIdAsync(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
