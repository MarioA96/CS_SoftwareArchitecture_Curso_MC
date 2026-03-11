using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface IMapper<TIn, TOut>
    {
        TOut Map(TIn input);
    }
}
