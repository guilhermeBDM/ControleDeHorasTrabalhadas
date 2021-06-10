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
    public class CarrinhoDataBase
    {
        public int CriarCarrinho(int idFornecedor, DateTime pedido, string dsPedido,decimal total)
        {
            string query = "insert into tb_pedido(id_fornecedor,dt_pedido,ds_pedido,vl_total) value({0},'{1}','{2}',{3})";
            query = string.Format(query,idFornecedor, pedido.ToString("yyyy-MM-dd"), dsPedido,total.ToString().Replace(',', '.'));
            ProjetoDataBase db = new ProjetoDataBase();
            return db.ExecuteInsertInt(query,null);
        }

        public void AddProdutoItem(int idPedido, string nomePedido, decimal valor, int quantidade)
        {
            string query = "insert into tb_pedido_item(id_pedido,nm_pedido,vl_produto,nr_quantidade) value({0},'{1}',{2},{3})";
            query = string.Format(query,idPedido,nomePedido,valor.ToString().Replace(',', '.'), quantidade);

            ProjetoDataBase db = new ProjetoDataBase();
            db.ExecuteInsert(query);
        }

        public List<DTOFornecedor> ListarFornecedores()
        {

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect("select * from tb_fornecedor");

            List<DTOFornecedor> listaFornecedor = new List<DTOFornecedor>();

            while (reader.Read())
            {
                DTOFornecedor dados = new DTOFornecedor();
                dados.IdForncedor = reader.GetInt32("id_fornecedor");
                dados.NomeFantasia = reader.GetString("nm_fantasia");

                listaFornecedor.Add(dados);
            }
            reader.Close();
            return listaFornecedor;
        }
    }
}
