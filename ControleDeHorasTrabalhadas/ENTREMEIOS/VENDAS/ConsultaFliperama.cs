using NSF.TCC.Sundown.DataAccess.QUERYS.VENDAS;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business.ENTREMEIOS.VENDAS
{
    public  class ConsultaFliperama
    {
        public List<ViewConsultaFliperama> ListAll()
        {
            ConsultasVendas db = new ConsultasVendas();
            List<ViewConsultaFliperama> flip = db.ListarVendasFliperama();

            return flip;
        }

        public void DeleteFliperama(int id)
        {
            ConsultasVendas db = new ConsultasVendas();
            db.DeleteFliperama(id);
        }
    }
}
