using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Entities
{
    public class ItemPedido
    {
//        ESSES ITENS DEVEM CONTER
//UM IDENTIFICADOR ÚNICO, 
//UM ÍNDICE ÚNICO POR PEDIDO, 
//O CÓDIGO DO PRODUTO,
//        A QUANTIDADE, 
//VALOR UNITÁRIO
//VALOR TOTAL(QUE DEVE CORRESPONDER A MULTIPLICAÇÃO DO VALOR UNITÁRIO PELA QUANTIDADE, E DEVERÁ SER CALCULADA PELO SISTEMA).
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public Decimal ValorTotal { get; set; }
    }
}
