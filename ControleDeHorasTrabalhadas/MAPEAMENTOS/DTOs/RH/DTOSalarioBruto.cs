using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOSalarioBruto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public decimal SalarioBruto { get; set; }
    }
}
