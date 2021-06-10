using NSF.TCC.Sundown.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class ChamarComplementosParc
    {

        public string Nome;
        public string Cnpj;
        public DateTime Comeco;
        public DateTime Fim;
        public string Desconto;



        public void BuscaUser(int id)
        {

            ChamarDadosParceiros cd = new ChamarDadosParceiros();


            cd.ListarParceiros(id);
           
            Nome = cd.Nome;
            Cnpj = cd.Cnpj;
            Comeco = cd.Comeco;
            Fim = cd.Fim;
            Desconto = cd.Desconto;
         
        }


    }
}

