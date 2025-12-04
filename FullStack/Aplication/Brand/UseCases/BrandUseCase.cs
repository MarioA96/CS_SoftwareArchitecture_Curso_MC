using Aplication.Abstractions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Brand.UseCases
{
    public class BrandUseCase : IUseCase<BrandEntity>
    {
        private IRepository<BrandEntity> _repository;
        public BrandUseCase(IRepository<BrandEntity> repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<BrandEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<BrandEntity> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(BrandEntity entity)
               => await _repository.AddAsync(entity);

        public async Task UpdateAsync(BrandEntity entity)
            => await _repository.UpdateAsync(entity);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}
