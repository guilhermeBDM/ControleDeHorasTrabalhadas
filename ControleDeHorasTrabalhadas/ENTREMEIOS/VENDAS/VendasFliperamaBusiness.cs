using NSF.TCC.Sundown.DataAccess.QUERYS.VENDAS;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.VENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business.ENTREMEIOS.VENDAS
{
    public class VendasFliperamaBusiness
    {
        public void Salvar(DTOIngressoFliperama dados)
        {
            VendasFliperamaDataBase salvar = new VendasFliperamaDataBase();
            dados.CPF = dados.CPF == "   .   .   -" ? "Não ident" : dados.CPF;


            salvar.Salvar(dados);
        }
    }
}
