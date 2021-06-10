using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class PermissaoBusiness
    {
        public DTOPermission Permin(int id)
        {
            PermissaoDataBase c = new PermissaoDataBase();
            DTOPermission a = c.Permin(id);

            if (a.IdUser >= 1)
                return a;
            else
                a.IdUser = 0;
            return a;

        }
    }
}
