using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Entities
{
    public class Produto
    {
        //UM ÍNDICE ÚNICO POR PRODUTO,  ==> OK
        //O CÓDIGO DO PRODUTO,  ==> OK
        //A QUANTIDADE,  ==> OK
        //VALOR UNITÁRIO ==> OK

        public int Id { get; set; }
        public string CodidoProduto { get; set; }
        public Decimal Valor { get; set; }
    }
}
