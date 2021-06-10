using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
   public class ListarParceirosBusiness
    {
        public List<DTOParceiros> ListAll()
        {
            CrudDataBase db = new CrudDataBase();
            List<DTOParceiros> parceiros = db.ListarParceiros();

            return parceiros;
        }
    }
}
