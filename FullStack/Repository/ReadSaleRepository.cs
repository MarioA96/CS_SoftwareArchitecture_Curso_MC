using Aplication.Abstractions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReadSaleRepository : IReadRepository<SaleEntity>
    {
        private readonly StoreContext _context;

        public ReadSaleRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<SaleEntity> GetByIdAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentException("Id debe ser mayor a 0.", nameof(id));

            var sale = await _context.Sales.Include(s => s.SaleDetails).FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
                throw new KeyNotFoundException($"La venta con el Id={id}, no existe.");

            return MapToEntity(sale);
        }

        public async Task<IEnumerable<SaleEntity>> GetAllAsync()
        {
            var sales = await _context.Sales.Include(s => s.SaleDetails).ToListAsync();

            return sales.Select(MapToEntity);
        }

        #region Mappers
        public static SaleEntity MapToEntity(Sale model)
        {
            var saleEntity = new SaleEntity(model.Date, model.Id);

            foreach (var saleDetail in model.SaleDetails)
            {
                saleEntity.AddDetail(new SaleDetailEntity(
                        model.Id,
                        saleDetail.ProductId,
                        saleDetail.Quantity,
                        saleDetail.UnitPrice,
                        saleDetail.Id
                 ));
            }

            return saleEntity;
        }
        #endregion
    }
}
