using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOCargos
    {
        public int IdCargo { get; set; }
        public int IdUser { get; set; }
        public bool Marketing { get; set; }
        public bool Rh { get; set; }
        public bool Contabilidade { get; set; }
        public bool GerenteLocal { get; set; }
        public bool AGeral { get; set; }
    }
}
