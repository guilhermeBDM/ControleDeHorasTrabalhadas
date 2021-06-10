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
    public class SessaoDataBase
    {
        public void InserirSessao(DTOSessao see)
        {
            string query = "insert into tb_sessao(nm_filme,ft_img,ds_filme,ds_faixa_etaria,dt_inicio_filme,dt_final_filme,dt_inico_vendas,nr_quantidade_cadeira) value(@nome,@foto,@descri,@faixaEta,@inicioFilme,@finalFimel,@dtLanca,@numCadeiras)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome", see.Nome));
            parameters.Add(new MySqlParameter("foto", see.Foto));
            parameters.Add(new MySqlParameter("descri", see.Descricao));
            parameters.Add(new MySqlParameter("faixaEta", see.FaixaEtaria));
            parameters.Add(new MySqlParameter("inicioFilme", see.InicioFilme.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("finalFimel", see.FinalFilme.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("dtLanca", see.DataLancamento.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("numCadeiras", see.NumeroDeCadeiras));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }

        public void AtualizarSessao(DTOSessao see)
        {
            string query = "Update tb_sessao set nm_filme = @nome, ft_img = @foto ,ds_filme = @descri, ds_faixa_etaria = @faixaEta, dt_inicio_filme = @inicioFilme, dt_final_filme = @finalFimel, dt_inico_vendas = @dtLanca ,nr_quantidade_cadeira = @numCadeiras where id_sessao = @idS";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idS", see.IDSessao));
            parameters.Add(new MySqlParameter("nome", see.Nome));
            parameters.Add(new MySqlParameter("foto", see.Foto));
            parameters.Add(new MySqlParameter("descri", see.Descricao));
            parameters.Add(new MySqlParameter("faixaEta", see.FaixaEtaria));
            parameters.Add(new MySqlParameter("inicioFilme", see.InicioFilme.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("finalFimel", see.FinalFilme.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("dtLanca", see.DataLancamento.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("numCadeiras", see.NumeroDeCadeiras));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }

        public void DeleteSessao(int id)
        {
            string query = "Delete from tb_sessao where id_sessao = @id_sessao";
            string queryDelete = "Delete from tb_ingresso_sessao where id_sessao = {0}";
            queryDelete = string.Format(queryDelete, id);
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_sessao", id));

            ProjetoDataBase data = new ProjetoDataBase();
            data.ExecuteInsert(queryDelete);
            data.ExecuteInsertParamters(query,parameters);
        }

        public List<DTOSessao> ListarAll()
        {
            string query = "select * from tb_sessao order by id_sessao desc";
            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader =  database.ExecuteSelectParamters(query,null);

            List<DTOSessao> lista = new List<DTOSessao>();

            while (reader.Read())
            {
                DTOSessao dados = new DTOSessao();
                dados.IDSessao = reader.GetInt32("id_sessao");
                dados.Nome = reader.GetString("nm_filme");
                dados.Foto = (byte[])(reader["ft_img"]);
                dados.Descricao = reader.GetString("ds_filme");
                dados.FaixaEtaria = reader.GetString("ds_faixa_etaria");
                dados.InicioFilme = reader.GetDateTime("dt_inicio_filme");
                dados.FinalFilme = reader.GetDateTime("dt_final_filme");
                dados.DataLancamento = reader.GetDateTime("dt_inico_vendas");
                dados.NumeroDeCadeiras = reader.GetInt32("nr_quantidade_cadeira");

                lista.Add(dados);
            }
            reader.Close();

            return lista;
        }


        public DTOSessao ListarID(int id)
        {
            string query = "select * from tb_sessao where id_sessao = {0} limit 1";
            query = string.Format(query,id);
            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query,null);

            DTOSessao dados = new DTOSessao();

            if (reader.Read())
            {
                dados.IDSessao = reader.GetInt32("id_sessao");
                dados.Nome = reader.GetString("nm_filme");
                dados.Foto = (byte[])(reader["ft_img"]);
                dados.Descricao = reader.GetString("ds_filme");
                dados.FaixaEtaria = reader.GetString("ds_faixa_etaria");
                dados.InicioFilme = reader.GetDateTime("dt_inicio_filme");
                dados.FinalFilme = reader.GetDateTime("dt_final_filme");
                dados.DataLancamento = reader.GetDateTime("dt_inico_vendas");
                dados.NumeroDeCadeiras = reader.GetInt32("nr_quantidade_cadeira");
            }
            reader.Close();

            return dados;
        }
    }
}
