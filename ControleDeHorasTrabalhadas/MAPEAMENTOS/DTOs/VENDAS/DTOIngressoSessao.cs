using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.MAPEAMENTOS.DTO_S.VENDAS
{
    public class DTOIngressoSessao
    {
        public int idIngressoSessao { get; set; }
        public int IdSessao { get; set; }
        public string NomeDoFilme { get; set; }
        public int NumeroDaCadeira { get; set; }
        public string Cpf { get; set; }
        public DateTime DtCompra { get; set; }
        public int IdPrecoSessao { get; set; }
        public bool BtMeia { get; set; }
        public DTOPrecoSessao AllPreco { get; set; }
    }
}
