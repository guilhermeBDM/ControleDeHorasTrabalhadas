using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOFuncionarioDoMes
    {
        public int Id { get; set; }
        public string Nome  { get; set; }
        public byte[] Foto { get; set; }
        public string parabenizacao { get; set; }

    }
}
