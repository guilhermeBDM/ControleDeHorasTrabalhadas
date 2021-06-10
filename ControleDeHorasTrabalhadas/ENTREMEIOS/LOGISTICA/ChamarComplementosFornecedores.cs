using NSF.TCC.Sundown.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class ChamarComplementosFornecedores
    {
         public string Nome;
        public string Cnpj;
        public string Fantasia;
        public string Cep;
        public int Numero;


        public void BuscarForn(int id)
        {

            ChamarDadosFornecedores cd = new ChamarDadosFornecedores();


            cd.ListarFornecedores(id);

            Nome = cd.Nome;
            Cnpj = cd.Cnpj;
            Fantasia = cd.Fantasia;
            Cep = cd.Cep;
            Numero = cd.Numero;

        }

    }
}
