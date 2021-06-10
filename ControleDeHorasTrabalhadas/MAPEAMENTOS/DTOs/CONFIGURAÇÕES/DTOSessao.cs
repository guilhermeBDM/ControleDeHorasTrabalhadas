using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOSessao
    {
        public int IDSessao { get; set; }
        public string Nome { get; set; }
        public byte[] Foto { get; set; }
        public string  Descricao{ get; set; }
        public string FaixaEtaria { get; set; }
        public DateTime InicioFilme { get; set; }
        public DateTime FinalFilme { get; set; }
        public DateTime DataLancamento { get; set; }
        public int NumeroDeCadeiras { get; set; }
    }
}
