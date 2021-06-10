using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.Views
{
    public class ViewFluxo
    {
        public DateTime Dia { get; set; }
        public decimal Valor { get; set; }
        public string Operacao { get; set; }
        public string Motivo { get; set; }
    }
}
