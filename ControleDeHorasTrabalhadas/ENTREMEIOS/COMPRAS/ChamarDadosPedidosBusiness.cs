using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.COMPRAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class ChamarDadosPedidosBusiness
    {
        public List<ViewPedidos> ListAll(int id)
        {
            ChamarDadosPedidos db = new ChamarDadosPedidos();
            List<ViewPedidos> dados = db.ListarPedidos(id);

            return dados;
        }
    }
}
