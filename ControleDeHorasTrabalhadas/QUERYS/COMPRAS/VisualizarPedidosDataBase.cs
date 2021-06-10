using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class VisualizarPedidosDataBase
    {

        public List<DTOPedido> ListarPedido()
        {

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters("select * from tb_pedido",null);

            List<DTOPedido> listaPedidos = new List<DTOPedido>();

            while (reader.Read())
            {
                DTOPedido dados = new DTOPedido();
                dados.IdPedido = reader.GetInt32("id_pedido");
                dados.DsPedido = reader.GetString("ds_pedido");

                listaPedidos.Add(dados);
            }
            reader.Close();

            return listaPedidos;
        }
    }
}
