using Aplication.Abstractions;
using Aplication.Product.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Product.Mappers
{
    public class ProductDtoToEntityMapper : IMapper<ProductDto, ProductEntity>
    {
        public ProductEntity Map(ProductDto productDto)
        {
            return productDto.Id == null ? 
                new ProductEntity(productDto.Name, productDto.Cost, productDto.Price, productDto.Active, productDto.BrandId)
                : new ProductEntity((int)productDto.Id, productDto.Name, productDto.Cost, productDto.Price, productDto.Active, productDto.BrandId);
        }
    }
}
