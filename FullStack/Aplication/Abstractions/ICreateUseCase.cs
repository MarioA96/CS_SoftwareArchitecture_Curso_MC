using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface ICreateUseCase<TDTO, TEntity>
    {
        Task AddAsync(TDTO dto);
    }
}
