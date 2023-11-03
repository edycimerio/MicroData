using FluentValidation;
using Micro.Data.Domain.Dtos;

namespace Micro.Data.API.Validadores
{
    public class PutProdutoValidator : AbstractValidator<ProdutoDto>
    {
        public PutProdutoValidator()
        {
            RuleFor(x => x.Id)
                  .NotEmpty().WithMessage("Informe o Id do produto")
                  .NotNull().WithMessage("Informe o Id do produto")
                  .GreaterThan(0).WithMessage("Informe o Id do produto maior do que 0");

            RuleFor(x => x.CodidoProduto)
                   .NotEmpty().WithMessage("Informe o Código do produto")
                   .NotNull().WithMessage("Informe o Código do produto")
                   .Length(3, 5).WithMessage("O Códido Produto deve ter no mínimo 3 caracteres e no máximo 5 caracteres");

            RuleFor(x => x.Valor)
                   .NotEmpty().WithMessage("Informe o Valor do produto")
                   .NotNull().WithMessage("Informe o Valor do produto")
                   .GreaterThan(0).WithMessage("Informe o Valor do produto maior do que 0");

        }
    }
}
