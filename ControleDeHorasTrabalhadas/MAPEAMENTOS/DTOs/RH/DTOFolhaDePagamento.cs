using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOFolhaDePagamento
    {
        public int IdFolha { get; set; }
        public int IdUsuario { get; set; }
        public int IdSalarioBruto { get; set; }
        public int Falta { get; set; }
        public int AtrasoMinutos { get; set; }
        public decimal HorasExtras { get; set; }
        public decimal salarioLiquido { get; set; }
        public DateTime DtDataUltimoPonto { get; set; }
        public DateTime DtDataRegistroFolha { get; set; }
    }
}
