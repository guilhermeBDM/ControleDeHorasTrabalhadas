using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.CHAT
{
    public class ViewChat
    {
        public int IdChat { get; set; }

        public bool Visualizou { get; set; }

        public int IdDestinatario { get; set; }

        public int IdRemetente { get; set; }

        public string Nome { get; set; }
    }
}
