using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class LoginDataBase
    {
        public int Login(string email, string senha)
        {
            string query = "select tb_usuario.id_usuario, tb_usuario.nm_nomedoatendente,tb_usuario.ds_email,tb_usuario.ds_senha from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario WHERE tb_demitidos.id_usuario is null and ds_email = @ds_email AND ds_senha = @ds_senha";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("ds_email", email));
            parameters.Add(new MySqlParameter("ds_senha", senha));

            ProjetoDataBase sql = new ProjetoDataBase();

            MySqlDataReader reader = sql.ExecuteSelectParamters(query, parameters);

            if (reader.Read() == true)
            {
               
                return reader.GetInt32("id_usuario");
            }
            else
            {
                reader.Close();
                return 0;
            }





        }

    }
}
