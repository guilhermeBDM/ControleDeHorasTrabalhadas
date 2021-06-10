using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.COMPRAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class ChamarDadosPedidos
    {
        
        public List<ViewPedidos> ListarPedidos(int id)
        {
            string query = "select * from vw_pedidos where id_pedido = @id_pedido";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_pedido", id));
            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            List<ViewPedidos> itens = new List<ViewPedidos>();



            while (reader.Read())
            {
                ViewPedidos Pedido = new ViewPedidos();

                Pedido.NomeProduto = reader.GetString("nm_pedido");
                Pedido.ValorProduto = reader.GetDecimal("vl_produto");
                Pedido.Quantidade = reader.GetInt32("nr_quantidade");
                Pedido.Fornecedor = reader.GetString("nm_fantasia");

                itens.Add(Pedido);

            }
            reader.Close();

            return itens;
        }
    }
}
