using NSF.TCC.Sundown.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHorasTrabalhadas
{
    public class DeleteBusiness
    {
        public void DeleteParceiro(int id)
        {
            DeleteDataBase ddb = new DeleteDataBase();
            ddb.RemoverParceiros(id);
          
        }
        public void DeleteTerc(int id)
        {
            DeleteDataBase ddb = new DeleteDataBase();
            ddb.RemoverTerc(id);

        }
        public void DeleteForn(int id)
        {
            DeleteDataBase ddb = new DeleteDataBase();
            ddb.RemoverForn(id);

        }
        public void DeletePedidoItem(int id)
        {
            DeleteDataBase ddb = new DeleteDataBase();
            ddb.RemoverPedidoItem(id);

        }
        public void DeletePedido(int id)
        {
            DeleteDataBase ddb = new DeleteDataBase();
            ddb.RemoverPedido(id);

        }


    }
}
