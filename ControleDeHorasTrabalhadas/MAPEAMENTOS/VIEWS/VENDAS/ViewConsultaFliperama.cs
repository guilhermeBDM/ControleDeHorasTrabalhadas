using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS
{
    public class ViewConsultaFliperama
    {
        public int IdFliperama { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDaCompra { get; set; }
        public float ValorUnitario { get; set; }
        public int QuantidadeDeFixas { get; set; }
    }
}
