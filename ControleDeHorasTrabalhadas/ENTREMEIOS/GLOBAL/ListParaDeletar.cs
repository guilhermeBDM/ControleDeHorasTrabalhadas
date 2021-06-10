using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class ListParaDeletar
    {
   
        public List<DTOParceiros> ListParceiros()
        {
            CrudDataBase db = new CrudDataBase();
            List<DTOParceiros> parceiros = db.ListarParceiros();

            return parceiros;
        }
        public List<DTOTerceirizado> ListTerceirizados()
        {
            CrudDataBase db = new CrudDataBase();
            List<DTOTerceirizado> terc = db.ListarTerceiros();

            return terc;
        }
        public List<DTOFornecedor> ListFornecedores()
        {
            CrudFornecedor db = new CrudFornecedor();
            List<DTOFornecedor> forn = db.ListarFornecedores();

            return forn;
        }
    }
}
