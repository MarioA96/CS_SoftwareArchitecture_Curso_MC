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
    public class CreateProductUseCase : ICreateUseCase<ProductDto, ProductEntity>
    {
        private readonly ICreateRepository<ProductEntity> _repository;
        private readonly IMapper<ProductDto, ProductEntity> _mapper;

        public CreateProductUseCase(
            ICreateRepository<ProductEntity> repository,
            IMapper<ProductDto, ProductEntity> mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map(productDto);
            await _repository.AddAsync(productEntity);
        }
    }
}
