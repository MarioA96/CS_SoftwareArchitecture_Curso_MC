using Aplication.Abstractions;
using Aplication.Product.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Product.UseCases
{
    public class UpdateProductUseCase : IUpdateUseCase<ProductDto, ProductEntity>
    {
        private readonly IUpdateRepository<ProductEntity> _repository;
        private readonly IMapper<ProductDto, ProductEntity> _mapper;

        public UpdateProductUseCase(
            IUpdateRepository<ProductEntity> repository,
            IMapper<ProductDto, ProductEntity> mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task UpdateAsync(ProductDto productDto, int id)
        {
            var productEntity = _mapper.Map(productDto);
            await _repository.UpdateAsync(productEntity, id);
        }
    }
}
