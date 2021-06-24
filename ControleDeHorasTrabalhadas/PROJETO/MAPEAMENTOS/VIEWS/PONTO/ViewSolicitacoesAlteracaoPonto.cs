using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas.MAPEAMENTOS.VIEWS.PONTO
{
    public class ViewSolicitacoesAlteracaoPonto
    {

        public int IdAlteracaoPonto { get; set; }
        public int IdPonto { get; set; }
        /* Movimento */
        public string Usuario { get; set; }
        public string Movimento { get; set; }
        /* Status */
        public string NovoMovimento { get; set; }
        public string Status { get; set; }
        public string NovoStatus { get; set; }

        public string Motivo { get; set; }
    }
}
