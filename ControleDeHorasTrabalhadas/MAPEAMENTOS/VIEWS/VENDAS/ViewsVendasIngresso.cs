using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS
{
    public class ViewsVendasIngresso
    {
        public int IDSessao { get; set; }
        public string Nome { get; set; }
        public string FaixaEtaria { get; set; }
        public string DtInicioFilme { get; set; }
        public int NumeroTotalCadeira { get; set; }
        public int QuantidadeVendida { get; set; }
    }
}
