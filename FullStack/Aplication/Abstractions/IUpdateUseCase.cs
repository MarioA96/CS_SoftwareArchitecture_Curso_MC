using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface IUpdateUseCase<TDTO, TEntity>
    {
        Task UpdateAsync(TDTO dto, int id);
    }
}
