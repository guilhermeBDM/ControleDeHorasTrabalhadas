using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.VOs
{
    public class VOConsultarFolha
    {
        public int IdFolha { get; set; }
        public string NomeUsuario { get; set; }
        public decimal SalarioBruto { get; set; }
        public bool ValeTransporte { get; set; }
        public decimal ValeRefeicao { get; set; }
        public decimal ValeAlimentacao { get; set; }
        public bool AssMedica { get; set; }
        public int SalarioFamilia { get; set; }
        public int AtrasoMinutos { get; set; }
        public decimal HoraExtra { get; set; }
        public int Falta { get; set; }
        public DateTime DataDaFolha { get; set; }
        public decimal SalarioLiquido { get; set; }
    }
}
