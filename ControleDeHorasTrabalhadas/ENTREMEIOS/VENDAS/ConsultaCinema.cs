using NSF.TCC.Sundown.DataAccess.QUERYS.VENDAS;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business.ENTREMEIOS.VENDAS
{
    public class ConsultaCinema
    {
        public List<ViewConsultaCinema> ListAll()
        {
            ConsultasVendas db = new ConsultasVendas();
            List<ViewConsultaCinema> cine = db.ListarVendas();

            return cine;
        }

        public void Delete(int id)
        {
            ConsultasVendas db = new ConsultasVendas();
            db.Delete(id);
        }

    }
}
