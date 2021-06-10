using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
   public class DTOParceiros
    {
        public int IdParceiro { get; set; }
        public string NameEnterprise { get; set; }
        public string Cnpj { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Discount { get; set; }
    }
}
