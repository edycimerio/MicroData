using FluentValidation;
using Micro.Data.Domain.Dtos;

namespace Micro.Data.API.Validadores
{
    public class PostPedidoValidator : AbstractValidator<PedidoDto>
    {

        public PostPedidoValidator()
        {
            RuleFor(x => x.Email)
                   .NotEmpty().WithMessage("Informe o e-mail do cliente")
                   .NotNull().WithMessage("Informe o e-mail do cliente")
                   .Length(10, 30).WithMessage("O e-mail deve ter no mínimo 10 caracteres e no máximo 30 caracteres")
                   .EmailAddress().WithMessage("O e-mail é inválido");

            RuleFor(x => x.DataPedido)
                   .NotEmpty().WithMessage("Informe o valor do produto")
                   .NotNull().WithMessage("Informe o valor do produto")
                   .Must(BeAValidDate).WithMessage("Informe uma data válida");

            RuleForEach(x => x.Itens).NotNull().WithMessage("Informe ao menos 1 item para fechar o pedido.");


            //    public string Email { get; set; }
            //public DateTime DataPedido { get; set; }
            //public Decimal ValorTotal { get; set; }
            //public IList<ItemPedidoDto> Itens { get; set; }


        }

        private bool BeAValidDate(DateTime date)
        {
            if (date == default(DateTime))
                return false;
            return true;
        }
        private bool BeAValidDate(DateTime? date)
        {
            if (date == default(DateTime))
                return false;
            return true;
        }
    }
}
