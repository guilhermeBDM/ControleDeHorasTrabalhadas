using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.CHAT;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.CHAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess.QUERYS.CHAT
{
    public class ChatDataBase
    {
        public List<ViewChat> SalaChat(int id)
        {
            string query = "select * from tb_chat_select where id_destinatario = {0} or id_destinatario = 0 and id_remetente <> {1} group by id_remetente order by bt_visualizou asc, id_chat desc, id_remetente asc";
            query = string.Format(query, id, id);

            ProjetoDataBase sql = new ProjetoDataBase();

            MySqlDataReader reader = sql.ExecuteSelect(query);

            List<ViewChat> dados = new List<ViewChat>();

            while (reader.Read())
            {
                ViewChat info = new ViewChat();

                info.IdChat = reader.GetInt32("id_chat");
                info.Visualizou = reader.GetBoolean("bt_visualizou");
                info.IdDestinatario = reader.GetInt32("id_destinatario");
                info.IdRemetente = reader.GetInt32("id_remetente");
                info.Nome = reader.GetString("nm_usuario");
                dados.Add(info);
            }
            reader.Close();
            return dados;

        }

        public List<DTOChat> Listar(int idDesti, int idRemt)
        {
            string query = "select * from tb_chat where (id_destinatario = {0} and id_remetente = {1}) or (id_destinatario = {2} and id_remetente = {3}) order by id_chat asc";
            query = string.Format(query, idDesti, idRemt, idRemt, idDesti);

            string queryUp = "update tb_chat set bt_visualizou = true where bt_visualizou = false and ((id_destinatario = {0} and id_remetente = {1}) or (id_destinatario = {2} and id_remetente = {3}))";
            queryUp = string.Format(queryUp, idDesti, idRemt, idRemt, idDesti);

            ProjetoDataBase sql = new ProjetoDataBase();
            sql.ExecuteInsert(queryUp);

            MySqlDataReader reader = sql.ExecuteSelect(query);

            List<DTOChat> dados = new List<DTOChat>();

            while (reader.Read())
            {
                DTOChat info = new DTOChat();

                info.IdChat = reader.GetInt32("id_chat");
                info.IdDestinatario = reader.GetInt32("id_destinatario");
                info.IdRemetente = reader.GetInt32("id_remetente");
                info.Visualizou = reader.GetBoolean("bt_visualizou");
                info.Texto = reader.GetString("ds_texto");
                info.Data = reader.GetDateTime("dt_envio");
                dados.Add(info);
            }
            reader.Close();
            return dados;

        }

        public List<DTOChat> Enviado(int idDesti, int idRemt)
        {
            string query = "select * from tb_chat where bt_visualizou = false and id_destinatario = {0} and id_remetente = {1} order by id_chat asc";
            query = string.Format(query, idDesti, idRemt);

            string queryUp = "update tb_chat set bt_visualizou = true where bt_visualizou = false and id_destinatario = {0} and id_remetente = {1}";
            queryUp = string.Format(queryUp, idDesti, idRemt);

            ProjetoDataBase sql = new ProjetoDataBase();

            MySqlDataReader reader = sql.ExecuteSelect(query);

            List<DTOChat> dados = new List<DTOChat>();

            while (reader.Read())
            {
                DTOChat info = new DTOChat();

                info.IdChat = reader.GetInt32("id_chat");
                info.IdDestinatario = reader.GetInt32("id_destinatario");
                info.IdRemetente = reader.GetInt32("id_remetente");
                info.Visualizou = reader.GetBoolean("bt_visualizou");
                info.Texto = reader.GetString("ds_texto");
                info.Data = reader.GetDateTime("dt_envio");
                dados.Add(info);
            }
            sql.ExecuteInsert(queryUp);
            reader.Close();
            return dados;
        }

        public void Mensagem(DTOChat dados)
        {
            string queryUp = "insert into tb_chat(id_destinatario,id_remetente,bt_visualizou,ds_texto,dt_envio) value(@dest,@remet,false,@text,@data)";


            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("dest", dados.IdDestinatario));
            parameters.Add(new MySqlParameter("remet", dados.IdRemetente));
            parameters.Add(new MySqlParameter("text", dados.Texto));
            parameters.Add(new MySqlParameter("data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            ProjetoDataBase sql = new ProjetoDataBase();
            sql.ExecuteInsertParamters(queryUp, parameters);
        }
    }
}
