using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas.MAPEAMENTOS.DTOs.PONTO
{
    class DTOAlteracaoPonto
    {
       


        public int Id { get; set; }
        public int IdPonto { get; set; }
        /* Movimento */
        public string Movimento { get; set; }
        /* Status */
        public string Status { get; set; }

        public string Motivo { get; set; }
    }
}
