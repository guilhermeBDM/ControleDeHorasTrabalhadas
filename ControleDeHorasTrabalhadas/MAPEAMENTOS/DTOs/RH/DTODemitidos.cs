using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTODemitidos
    {
        public int IdDemitidos { get; set; }
        public int IdUsuarios { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Causa { get; set; }
        public DateTime Dia { get; set; }

    }
}
