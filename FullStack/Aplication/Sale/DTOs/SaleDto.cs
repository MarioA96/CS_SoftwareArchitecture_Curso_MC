using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Sale.DTOs
{
    public class SaleDto
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public List<SaleDetailDto> Details { get; set; } = new();
        public decimal Total => Details?.Sum( d=>d.TotalPrice ) ?? 0;
    }
}
