using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTO_S.CONFIGURAÇÕES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class InserirValorVendasDataBase
    {

        public void InserirFliperama(decimal valor)
        {
            string query = "insert into  tb_preco_fliperama(vl_preco) value({0})";
            query = string.Format(query, valor.ToString().Replace(',', '.'));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, null);
        }

        public DTOPrecoIngresso ValorFliperama()
        {
            string query = "select * from tb_preco_fliperama order by id_preco_fliperama desc limit 1";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            DTOPrecoIngresso dados = new DTOPrecoIngresso();

            if (reader.Read())
            {
                dados.ID = reader.GetInt32("id_preco_fliperama");
                dados.Preco =  reader.GetDecimal("vl_preco");

            }
            reader.Close();
            return dados;

        }

        public void InserirCinema(decimal valor, string periodo)
        {
            string query = "insert into tb_preco_sessao(vl_preco,nm_periodo) value({0},'{1}')";
            query = string.Format(query, valor.ToString().Replace(',', '.'), periodo);

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, null);
        }

        public DTOPrecoSessao ValorCinema(string periodo)
        {
           string query = "select * from tb_preco_sessao  where nm_periodo = '{0}' order by id_preco_sessao desc limit 1";
           query = string.Format(query, periodo);

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            DTOPrecoSessao dados = new DTOPrecoSessao();

            if (reader.Read())
            {
                dados.Id = reader.GetInt32("id_preco_sessao");
                dados.Valor = reader.GetDecimal("vl_preco");
                dados.Periodo = reader.GetString("nm_periodo");
            }
            reader.Close();

            return dados;
        }
    }
}
