using Aplication.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Product.UseCases
{
    public class DeleteProuctUseCase : IDeleteUseCase
    {
        private readonly IDeleteRepository _repository;

        public DeleteProuctUseCase(IDeleteRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
