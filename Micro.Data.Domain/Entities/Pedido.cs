using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Entities
{
    public class Pedido
    {
        //ESTE PEDIDO DEVE CONTER APENAS UM IDENTIFICADOR ÚNICO, ==> OK
        //O EMAIL DO CLIENTE,  ==> OK
        //DATA ==> OK

        //ITEM  ==> NOK, entendi que estes campos devem estar na tabela de itens de pedido
        //VALOR UNITARIO DO ITEM  ==> NOK, entendi que estes campos devem estar na tabela de itens de pedido
        //VALOR TOTAL(SOMA DO VALOR TOTAL DOS ITENS, E DEVERÁ SER CALCULADA PELO SISTEMA).  ==> OK
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DataPedido { get; set; }
        public Decimal ValorTotal { get; set; }
    }
}
