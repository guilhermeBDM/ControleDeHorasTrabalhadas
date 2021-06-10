using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class ListarTerceirosBusiness
    {
        public List<DTOTerceirizado> ListAll()
        {
            CrudDataBase db = new CrudDataBase();
            List<DTOTerceirizado> terceiros = db.ListarTerceiros();
            return terceiros;
        }


    }
}
