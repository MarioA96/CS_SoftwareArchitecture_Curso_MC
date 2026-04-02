using FluentValidation;
using Frontend.Client;

namespace Frontend.Validators
{
    public class SaleDtoValidator : AbstractValidator<SaleDto>
    {
        public SaleDtoValidator()
        {
            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("La venta debe tener productos");

            RuleForEach(x => x.Details).ChildRules(details =>
            {
                details.RuleFor(x => x.ProductId)
                    .GreaterThan(0).WithMessage("El Id del producto debe ser mayor a 0");

                details.RuleFor(x => x.Quantity)
                    .GreaterThan(0).WithMessage("La cantidad de elementos debe ser mayor a 0");
            });

            RuleFor(x => x.Date)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("La fecha no puede ser del futuro");
        }
    }
}
