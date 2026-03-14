using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface IUpdateRepository<TEntity>
    {
        Task UpdateAsync(TEntity entity, int id);
    }
}
