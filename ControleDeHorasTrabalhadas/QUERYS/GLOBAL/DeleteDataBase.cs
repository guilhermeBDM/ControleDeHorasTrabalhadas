using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class DeleteDataBase
    {
        public void RemoverParceiros(int id)
        {
            string query = "DELETE FROM tb_parceiro WHERE id_parceiro = @id_parceiro";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_parceiro", id));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }

        public void RemoverTerc(int id)
        {
            string query = "DELETE FROM tb_terceirizado WHERE id_terc = @id_terc";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_terc", id));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }

        public void RemoverForn(int id)
        {
            string query = "DELETE FROM tb_fornecedor WHERE id_fornecedor = @id_fornecedor";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_fornecedor", id));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }

        public void RemoverPedidoItem(int id)
        {
            string query = "DELETE FROM tb_pedido_item WHERE id_pedido = @id_pedido ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_pedido", id));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }
        public void RemoverPedido(int id)
        {
            string query = "DELETE FROM tb_pedido WHERE id_pedido = @id_pedido ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_pedido", id));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }




    }
}
