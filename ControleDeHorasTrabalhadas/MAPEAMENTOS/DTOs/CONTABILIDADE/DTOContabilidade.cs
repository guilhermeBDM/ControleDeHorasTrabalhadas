using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.CONTABILIDADE
{
    public class DTOContabilidade
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public string Operacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
