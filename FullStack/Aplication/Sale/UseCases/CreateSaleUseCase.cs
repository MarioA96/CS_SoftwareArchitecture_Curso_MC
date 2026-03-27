using Aplication.Abstractions;
using Aplication.Sale.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Sale.UseCases
{
    public  class CreateSaleUseCase : ICreateUseCase<SaleDto, SaleEntity>
    {
        private readonly ICreateRepository<SaleEntity> _repository;
        private readonly IMapper<SaleDto, SaleEntity> _mapper;

        public CreateSaleUseCase(ICreateRepository<SaleEntity> repository, IMapper<SaleDto, SaleEntity> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(SaleDto saleDto)
        {
            if (saleDto == null)
            {
                throw new ArgumentNullException(nameof(SaleDto));
            }

            var saleEntity = _mapper.Map(saleDto);
            saleEntity.Validate();
            await _repository.AddAsync(saleEntity);
        }
    }
}
