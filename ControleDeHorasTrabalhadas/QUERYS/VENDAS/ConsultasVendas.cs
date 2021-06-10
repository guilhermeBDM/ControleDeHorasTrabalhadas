using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess.QUERYS.VENDAS
{
    public class ConsultasVendas
    {
        public List<ViewConsultaCinema> ListarVendas()
        {
            string query = "select * from vw_consulta_cinema";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            List<ViewConsultaCinema> itens = new List<ViewConsultaCinema>();

            while (reader.Read())
            {
                ViewMeia meia = new ViewMeia();
                ViewConsultaCinema cine = new ViewConsultaCinema();
                cine.IdIngresso = reader.GetInt32("id_ingresso_sessao");
                cine.Cpf = reader.GetString("ds_cpf");
                cine.Cadeira = reader.GetInt32("nr_cadeira");
                cine.Preco = reader.GetDecimal("vl_preco");
                cine.DataDaCompra = reader.GetDateTime("dt_compra");
                cine.NomeDoFilme = reader.GetString("nm_filme");
                meia.Meia = reader.GetBoolean("bt_meia");

                if (meia.Meia == true)
                {
                    cine.MeiaString = "SIM";
                }
                else
                {
                    cine.MeiaString = "NÃO";

                }
                itens.Add(cine);

            }
            reader.Close();

            return itens;
        }

        public List<ViewConsultaFliperama> ListarVendasFliperama()
        {
            string query = "select * from vw_consulta_fliperama";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            List<ViewConsultaFliperama> itens = new List<ViewConsultaFliperama>();

            while (reader.Read())
            {

                ViewConsultaFliperama flip = new ViewConsultaFliperama();
                flip.IdFliperama = reader.GetInt32("id_ingresso_fliperama");
                flip.Cpf = reader.GetString("ds_cpf");
                flip.ValorUnitario = reader.GetFloat("vl_preco");
                flip.DataDaCompra = reader.GetDateTime("dt_compra");
                flip.QuantidadeDeFixas = reader.GetInt32("nr_fixas");
                itens.Add(flip);

            }
            reader.Close();

            return itens;
        }

        public void Delete(int id)
        {
            string queryDelete = "Delete from tb_ingresso_sessao where id_ingresso_sessao = {0}";
            queryDelete = string.Format(queryDelete, id);

            ProjetoDataBase data = new ProjetoDataBase();
            data.ExecuteInsert(queryDelete);
        }

        public void DeleteFliperama(int id)
        {
            string queryDelete = "Delete from tb_ingresso_fliperama where id_ingresso_fliperama = {0}";
            queryDelete = string.Format(queryDelete, id);

            ProjetoDataBase data = new ProjetoDataBase();
            data.ExecuteInsert(queryDelete);
        }

    }
}
