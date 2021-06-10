using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTO_S.VENDAS;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess.QUERYS.VENDAS
{
    public class VendaIngressoDataBase
    {
        public List<ViewsVendasIngresso> Filmes(string periodo)
        {
            string query = "select tb_sessao.id_sessao, tb_sessao.nm_filme, tb_sessao.ds_faixa_etaria, tb_sessao.dt_inicio_filme, tb_sessao.nr_quantidade_cadeira, count(tb_ingresso_sessao.id_ingresso_sessao) as nr_cadeira_vendidas from tb_sessao left join tb_ingresso_sessao on tb_ingresso_sessao.id_sessao = tb_sessao.id_sessao where dt_inico_vendas <= '{0}' and dt_final_filme >= '{1}' and (select count(id_ingresso_sessao) from tb_ingresso_sessao where id_sessao = tb_sessao.id_sessao) < nr_quantidade_cadeira group by tb_sessao.id_sessao, tb_sessao.nm_filme, tb_sessao.ds_faixa_etaria, tb_sessao.dt_inicio_filme, tb_sessao.nr_quantidade_cadeira";

            query = string.Format(query, periodo, periodo);

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            List<ViewsVendasIngresso> lista = new List<ViewsVendasIngresso>();

            while (reader.Read())
            {
                if (reader.GetString("id_sessao") != null)
                {
                    ViewsVendasIngresso dados = new ViewsVendasIngresso();
                    dados.IDSessao = reader.GetInt32("id_sessao");
                    dados.Nome = reader.GetString("nm_filme");
                    dados.FaixaEtaria = reader.GetString("ds_faixa_etaria");
                    dados.DtInicioFilme = reader.GetDateTime("dt_inicio_filme").ToString("yyyy-MM-dd HH:mm:ss");
                    dados.NumeroTotalCadeira = reader.GetInt32("nr_quantidade_cadeira");
                    dados.QuantidadeVendida = reader.GetInt32("nr_cadeira_vendidas");
                    lista.Add(dados);
                }
            }
            reader.Close();

            return lista;
        }

        public List<int> Cadeiras(int idSessao)
        {
            string query = "select * from tb_ingresso_sessao where id_sessao = {0}";

            query = string.Format(query, idSessao);

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            List<int> lista = new List<int>();

            while (reader.Read())
            {
                lista.Add(reader.GetInt32("nr_cadeira"));
            }
            reader.Close();

            return lista;
        }

        public DTOPrecoSessao PrecoManha()
        {
            string query = "select * from tb_preco_sessao where nm_periodo = 'MANHÃ' order by id_preco_sessao desc limit 1";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            DTOPrecoSessao dados = new DTOPrecoSessao();

            if (reader.Read())
            {
                dados.Id = reader.GetInt32("id_preco_sessao");
                dados.Periodo = reader.GetString("nm_periodo");
                dados.Valor = reader.GetDecimal("vl_preco");
            }
            reader.Close();

            return dados;
        }

        public DTOPrecoSessao PrecoTarde()
        {
            string query = "select * from tb_preco_sessao where nm_periodo = 'TARDE' order by id_preco_sessao desc limit 1";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            DTOPrecoSessao dados = new DTOPrecoSessao();

            if (reader.Read())
            {
                dados.Id = reader.GetInt32("id_preco_sessao");
                dados.Periodo = reader.GetString("nm_periodo");
                dados.Valor = reader.GetDecimal("vl_preco");
            }
            reader.Close();

            return dados;
        }

        public DTOPrecoSessao PrecoNoite()
        {
            string query = "select * from tb_preco_sessao where nm_periodo = 'NOITE' order by id_preco_sessao desc limit 1;";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            DTOPrecoSessao dados = new DTOPrecoSessao();

            if (reader.Read())
            {
                dados.Id = reader.GetInt32("id_preco_sessao");
                dados.Periodo = reader.GetString("nm_periodo");
                dados.Valor = reader.GetDecimal("vl_preco");
            }
            reader.Close();

            return dados;
        }

        public DTOPrecoSessao Preco3D()
        {
            string query = "select * from tb_preco_sessao where nm_periodo = '3D' order by id_preco_sessao desc limit 1;";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            DTOPrecoSessao dados = new DTOPrecoSessao();

            if (reader.Read())
            {
                dados.Id = reader.GetInt32("id_preco_sessao");
                dados.Periodo = reader.GetString("nm_periodo");
                dados.Valor = reader.GetDecimal("vl_preco");
            }
            reader.Close();

            return dados;
        }

        public List<int> Cadeira(int idSessao)
        {
            string query = "select nr_cadeira from tb_ingresso_sessao where id_sessao = {0}";

            query = string.Format(query, idSessao);

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);
            List<int> listDados = new List<int>();

            while (reader.Read())
            {
                listDados.Add(reader.GetInt32("nr_cadeira"));
            }
            reader.Close();

            return listDados;
        }

        public void Salvar(DTOIngressoSessao dados)
        {
            string query = "insert into tb_ingresso_sessao(id_sessao, ds_cpf, dt_compra, id_preco_sessao, nr_cadeira, bt_meia) value(@id_sessao,@ds_cpf,@dt_compra,@id_preco_sessao,@nr_cadeira,@bt_meia)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_sessao", dados.IdSessao));
            parameters.Add(new MySqlParameter("ds_cpf", dados.Cpf));
            parameters.Add(new MySqlParameter("dt_compra", dados.DtCompra.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("id_preco_sessao", dados.IdPrecoSessao));
            parameters.Add(new MySqlParameter("nr_cadeira", dados.NumeroDaCadeira));
            parameters.Add(new MySqlParameter("bt_meia", dados.BtMeia));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }


    }
}
