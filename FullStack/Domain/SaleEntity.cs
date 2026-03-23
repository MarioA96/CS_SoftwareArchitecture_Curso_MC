using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SaleEntity
    {
        public int? Id { get; private set; }
        public DateTime Date { get; private set; }
        
        public List<SaleDetailEntity> Details { get; private set; }
        public decimal Total => Details.Sum( d=>d.TotalPrice );
        public SaleEntity(DateTime date, int? id = null)
        {
            if (id.HasValue && id <= 0)
                throw new ArgumentException("Id debe ser mayor a 0.", nameof(id));
            if (date > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser del futuro", nameof(date));

            Id = id;
            Date = date;
            Details = new List<SaleDetailEntity>();
        }

        public void AddDetail(SaleDetailEntity detail)
        {
            if (detail == null)
                throw new ArgumentException(nameof(detail));

            Details.Add(detail);
        }

        public void RemoveDetail(int productId)
        {
            var detail = Details.FirstOrDefault( d => d.ProductId == productId );
            if (detail == null)
                throw new InvalidOperationException("El producto no existe en los de la venta.");

            Details.Remove(detail);
        }

        public void SetDate(DateTime date)
        {
            if (date > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser del futuro", nameof(date));

            Date = date;
        }

        public void Validate()
        {
            if (!Details.Any())
                throw new InvalidOperationException("La venta debe tener al menos un detalle.");
        }
    }
}
