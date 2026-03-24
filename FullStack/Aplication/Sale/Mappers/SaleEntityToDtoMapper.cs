using Aplication.Abstractions;
using Aplication.Sale.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Sale.Mappers
{
    public class SaleEntityToDtoMapper : IMapper<SaleEntity, SaleDto>
    {
        public SaleDto Map(SaleEntity saleEntity)
        {
            if (saleEntity == null)
                throw new ArgumentNullException(nameof(saleEntity));

            var saleDto = new SaleDto
            {
                Id = saleEntity.Id,
                Date = saleEntity.Date,
                Details = saleEntity.Details?.Select(d => new SaleDetailDto { 
                    Id = d.Id,
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    SaleId = d.SaleId,
                }).ToList() ?? new List<SaleDetailDto>()
            };

            return saleDto;
        }
    }
}
