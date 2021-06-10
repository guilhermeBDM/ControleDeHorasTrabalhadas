using NSF.TCC.Sundown.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class ChamarComplementoTerc
    {

        public string Nome;
        public string Cnpj;
        public DateTime Comeco;
        public DateTime Fim;



        public void BuscaUser(int id)
        {

            ChamarDadosTerc cd = new ChamarDadosTerc();


            cd.ListarTerceirizadas(id);

            Nome = cd.Nome;
            Cnpj = cd.Cnpj;
            Comeco = cd.Comeco;
            Fim = cd.Fim;

        }

    }
}
