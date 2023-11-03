using FluentValidation;
using Micro.Data.Domain.Dtos;

namespace Micro.Data.API.Validadores
{
    public class DeleteProdutoValidator : AbstractValidator<ProdutoDto>
    {
        public DeleteProdutoValidator()
        {
            RuleFor(x => x.Id)
                  .NotEmpty().WithMessage("Informe o Id do produto")
                  .NotNull().WithMessage("Informe o Id do produto")
                  .GreaterThan(0).WithMessage("Informe o Id do produto maior do que 0");


        }
    }
}
