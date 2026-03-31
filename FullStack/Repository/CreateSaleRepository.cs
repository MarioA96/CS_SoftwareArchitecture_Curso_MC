using Aplication.Abstractions;
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CreateSaleRepository : ICreateRepository<SaleEntity>
    {
        private readonly StoreContext _context;

        public CreateSaleRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SaleEntity saleEntity)
        {
            if(saleEntity == null)
                throw new ArgumentNullException(nameof(saleEntity));

            var sale = MapToModel(saleEntity);
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        #region Mappers
        public static Sale MapToModel(SaleEntity entity)
        {
            var sale = new Sale
            {
                Date = entity.Date,
            };

            foreach (var detailEntity in entity.Details)
            {
                var saleDetail = new SaleDetail
                {
                    ProductId = detailEntity.ProductId,
                    Quantity = detailEntity.Quantity,
                    UnitPrice = detailEntity.UnitPrice,
                };

                sale.SaleDetails.Add(saleDetail);
            }

            return sale;
        }
        #endregion
    }
}
