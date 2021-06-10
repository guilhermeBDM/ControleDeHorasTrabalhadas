using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS
{
    public class ViewConsultaCinema
    {
        public int IdIngresso { get; set; }
        public string Cpf { get; set; }
        public int Cadeira { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataDaCompra { get; set; }
        public string NomeDoFilme { get; set; }
        public string MeiaString { get; set; }

    }
}
