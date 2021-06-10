using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOFornecedor
    {
        public int IdForncedor { get; set; }
        public string RazãoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string CodigoPostal { get; set; }
        public int Numero { get; set; }
    }
}
