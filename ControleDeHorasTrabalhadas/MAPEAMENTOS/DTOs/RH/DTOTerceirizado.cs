using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOTerceirizado
    {
        public int IdTerc { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
    }
}
