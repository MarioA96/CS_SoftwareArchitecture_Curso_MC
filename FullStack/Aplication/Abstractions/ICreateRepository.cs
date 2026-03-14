using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface ICreateRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
    }
}
