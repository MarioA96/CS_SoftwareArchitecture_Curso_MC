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
    public class ProductRepository : 
        IReadRepository<ProductEntity>, 
        ICreateRepository<ProductEntity>, 
        IUpdateRepository<ProductEntity>,
        IDeleteRepository
    {
        private StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                throw new KeyNotFoundException($"Producto no existente con id: {id}");
            }
            return MapToEntity(product);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(MapToEntity);
        }

        public async Task AddAsync(ProductEntity productEntity)
        {
            var product = MapToModel(productEntity);
            product.Date = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity productEntity, int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"El producto con id={id}, no existe.");

            MapToModel(productEntity, product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"El producto con id={id} no existe.");
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        #region Mapper

        private static ProductEntity MapToEntity(Product model)
        {
            return new ProductEntity(
                model.Id, model.Name, model.Cost, model.Price, model.Active, model.BrandId
            );
        }

        private static Product MapToModel(ProductEntity entity)
        {
            return new Product
            {
                Name = entity.Name,
                Cost = entity.Cost,
                Price = entity.Price,
                Active = entity.Active,
                BrandId = entity.BrandId
            };
        }

        private static void MapToModel(ProductEntity entity, Product product)
        {
            product.Name = entity.Name;
            product.Cost = entity.Cost;
            product.Price = entity.Price;
            product.Active = entity.Active;
            product.BrandId = entity.BrandId;
        }
        
        #endregion
    }
}
