using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.VENDAS
{
    public class DTOIngressoFliperama
    {
        public int ID { get; set; }
        public string CPF { get; set; }
        public DateTime DtCompra { get; set; }
        public int IdPreco { get; set; }
        public int NumFichas { get; set; }
    }
}
