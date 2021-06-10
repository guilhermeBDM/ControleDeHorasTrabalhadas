using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class ConsultaFornecedores
    {

        public List<DTOFornecedor> ListAll()
        {
            CrudFornecedor db = new CrudFornecedor();
            List<DTOFornecedor> fornecedores = db.ListarFornecedores();

            return fornecedores;
        }

    }
}
