using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class DTOPonto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        /* Movimento */
        public string Movement { get; set; }
        /* Status */
        public string Status { get; set; }
    }

}
