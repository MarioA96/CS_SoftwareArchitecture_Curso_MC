using Aplication.Abstractions;
using Aplication.Sale.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Sale.Mappers
{
    public class SaleDtoToEntityMapper : IMapper<SaleDto, SaleEntity>
    {
        public SaleEntity Map(SaleDto saleDto)
        {
            if (saleDto == null)
                throw new ArgumentNullException(nameof(saleDto));

            var saleEntity = new SaleEntity(saleDto.Date, saleDto.Id);

            if (saleDto.Details != null)
            {
                foreach (var detailDto in saleDto.Details)
                {
                    var detailEntity = new SaleDetailEntity(
                        saleDto.Id,
                        detailDto.ProductId,
                        detailDto.Quantity,
                        detailDto.UnitPrice,
                        detailDto.Id
                        );
                    saleEntity.Details.Add( detailEntity );
                }
                
            }

            return saleEntity;
        }
    }
}
