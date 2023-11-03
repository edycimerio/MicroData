using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string CodidoProduto { get; set; }
        public Decimal Valor { get; set; }
    }
}
