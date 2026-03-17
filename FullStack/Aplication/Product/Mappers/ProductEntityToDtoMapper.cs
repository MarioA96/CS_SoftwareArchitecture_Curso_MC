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
    public class ProductEntityToDtoMapper : IMapper<ProductEntity, ProductDto>
    {
        public ProductDto Map(ProductEntity productEntity)
        {
            if (productEntity == null)
                throw new ArgumentNullException(nameof(productEntity));
            return new ProductDto
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Cost = productEntity.Cost,
                Price = productEntity.Price,
                Active = productEntity.Active,
                BrandId = productEntity.BrandId
            };
        }
    }
}
