using Aplication.Abstractions;
using Aplication.Sale.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Sale.UseCases
{
    public class ReadSaleUseCase : IReadUseCase<SaleDto, SaleEntity>
    {
        private readonly IReadRepository<SaleEntity, SaleDto> _repository;
        private readonly IMapper<SaleEntity, SaleDto> _mapper;

        public ReadSaleUseCase(IReadRepository<SaleEntity> repository, IMapper<SaleEntity, SaleDto> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<SaleDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id debe ser mayor a 0.", nameof(id));
            }
            var saleEntity = await _repository.GetByIdAsync(id);
            if(saleEntity == null)
            {
                return null;
            }
            var saleDto = _mapper.Map(saleEntity);
            return saleDto;
        }

        public async Task<IEnumerable<SaleDto>> GetAllAsync()
        {
            var saleEntities = await _repository.GetAllAsync();
            var saleDtos = saleEntities.Select(_mapper.Map);
            return saleDtos;
        }
    }
}
