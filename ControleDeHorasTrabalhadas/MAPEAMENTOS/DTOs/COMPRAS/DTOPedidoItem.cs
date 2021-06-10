using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOPedidoItem
    {
        public int IdPedidoItem { get; set; }
        public int IdPedido { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
