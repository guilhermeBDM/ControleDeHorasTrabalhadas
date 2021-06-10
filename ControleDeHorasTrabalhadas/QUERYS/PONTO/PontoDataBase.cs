using ControleDeHorasTrabalhadas;
using ControleDeHorasTrabalhadas.MAPEAMENTOS.VIEWS.PONTO;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class PontoDataBase
    {
        public void CriarPonto(int id, string data, string status)
        {

            string query = "insert into tb_ponto(id_usuario, ds_status, dt_movimento) value({0},'{1}','{2}')";
            query = string.Format(query, id, status, data);
            ProjetoDataBase db = new ProjetoDataBase();
            db.ExecuteInsert(query);

        }

        public void CriarPedidoAlteracao(int idPonto, string data, string status,string motivo)
        {

            string query = "insert into tb_alteracao_ponto(id_ponto, dt_novo_movimento, ds_status, ds_motivo) value({0},'{1}','{2}','{3}')";
            query = string.Format(query, idPonto, data, status, motivo);
            ProjetoDataBase db = new ProjetoDataBase();
            db.ExecuteInsert(query);

        }
        public void AlterarPonto(int idPonto, string data, string status)
        {

            string query = "UPDATE tb_ponto SET dt_movimento = '{0}', ds_status = '{1}' where id_ponto = {2};";
            query = string.Format(query, data, status, idPonto);
            ProjetoDataBase db = new ProjetoDataBase();
            db.ExecuteInsert(query);

        }

        public void DeletarPedidoAlteracao(int idAlteracaoPonto)
        {

            string query = "DELETE FROM tb_alteracao_ponto WHERE id_alteracao_ponto = {0};";
            query = string.Format(query, idAlteracaoPonto);
            ProjetoDataBase db = new ProjetoDataBase();
            db.ExecuteInsert(query);

        }
        public void DeletarPonto(int idPonto)
        {

            string query = "DELETE FROM tb_ponto WHERE id_ponto = {0};";
            query = string.Format(query, idPonto);
            ProjetoDataBase db = new ProjetoDataBase();
            db.ExecuteInsert(query);

        }
        public DTOPonto RetornarUltimo(int idUsuario)
        {
            string query = "SELECT  ds_status, dt_movimento FROM tb_ponto WHERE id_usuario = {0} ORDER BY id_ponto DESC LIMIT 1";
            query = string.Format(query,idUsuario);



            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            DTOPonto baseDados = new DTOPonto();
            
            if (read.Read())
            {
                baseDados.Movement = read.GetDateTime("dt_movimento").ToString("yyyy-dd-MM HH:mm:ss");
                baseDados.Status = read.GetString("ds_status");
            }
            read.Close();

            return baseDados;
        }
       
        public List<DTOUser> ListarUsuarios()
        {
            string query = "select * from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario where tb_demitidos.id_usuario is null";
            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            List<DTOUser> loop = new List<DTOUser>();

            while (read.Read())
            {
                DTOUser reg = new DTOUser();
                reg.Id = read.GetInt32("id_usuario");
                reg.Nome = read.GetString("nm_nomedoatendente");
                reg.User = read.GetString("nm_usuario");
                loop.Add(reg);
            }
            read.Close();

            return loop;
        }

        public DTOUser ListAllDadosUser(int id)
        {

            string query = "select * from tb_usuario where id_usuario = {0};";
            query = string.Format(query, id);

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            DTOUser reg = new DTOUser();

            while (read.Read())
            {
                reg.Id = read.GetInt32("id_usuario");
                reg.Nome = read.GetString("nm_nomedoatendente");
                reg.User = read.GetString("nm_usuario");
            }
            read.Close();

            return reg;

        }


        public List<DTOPonto> ListarPonto(int id, string data)
        {
            string query = "select id_ponto,dt_movimento, ds_status from tb_ponto where id_usuario = {0} and dt_movimento like '{1}%' order by id_ponto asc;";

            query = string.Format(query, id, data);

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            List<DTOPonto> loop = new List<DTOPonto>();

            while (read.Read())
            {
                DTOPonto reg = new DTOPonto();
                reg.Id = read.GetInt32("id_ponto");
                reg.Movement = read.GetString("dt_movimento");
                reg.Status = read.GetString("ds_status");
         
                loop.Add(reg);
            }

            read.Close();
            return loop;
        }

        public List<ViewSolicitacoesAlteracaoPonto> ListarPedidosAlteracao()
        {
            string query = "select * from vw_consulta_solicitacoes;";

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            List<ViewSolicitacoesAlteracaoPonto> loop = new List<ViewSolicitacoesAlteracaoPonto>();

            while (read.Read())
            {
                ViewSolicitacoesAlteracaoPonto reg = new ViewSolicitacoesAlteracaoPonto();
                reg.IdAlteracaoPonto = read.GetInt32("id_alteracao_ponto");
                reg.IdPonto = read.GetInt32("id_ponto");
                reg.Usuario = read.GetString("nm_usuario");
                reg.Movimento = read.GetString("dt_movimento");
                reg.NovoMovimento = read.GetString("dt_novomovimento");
                reg.Status = read.GetString("ds_status");
                reg.NovoStatus = read.GetString("ds_novostatus");
                reg.Motivo = read.GetString("ds_motivo");

                loop.Add(reg);
            }

            read.Close();
            return loop;
        }
    }
}
