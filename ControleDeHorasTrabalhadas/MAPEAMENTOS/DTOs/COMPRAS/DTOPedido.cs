using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOPedido
    {
        public int IdPedido { get; set; }
        public int IdForncedor { get; set; }
        public DateTime DtPedido  { get; set; }
        public string DsPedido { get; set; }
        public decimal Total { get; set; }
    }
}
