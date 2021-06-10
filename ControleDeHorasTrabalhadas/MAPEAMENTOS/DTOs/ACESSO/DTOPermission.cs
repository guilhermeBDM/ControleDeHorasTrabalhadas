using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
   public class DTOPermission
    {
        public int IdPermission { get; set; }
        public int IdUser { get; set; }
        public bool Administrator { get; set; }
        public bool Rh { get; set; }
        public bool Fin { get; set; }
        public bool Cont {get; set; }
        public bool Comp { get; set; }
        public bool Vend { get; set; }
    }
}
