using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.CHAT
{
    public class DTOChat
    {
        public int IdChat { get; set; }

        public int IdDestinatario { get; set; }

        public int IdRemetente { get; set; }

        public bool Visualizou { get; set; }

        public string Texto { get; set; }

        public DateTime Data { get; set; }
    }
}
