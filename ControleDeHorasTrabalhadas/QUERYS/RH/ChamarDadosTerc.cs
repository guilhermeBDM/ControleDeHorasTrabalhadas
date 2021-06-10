using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class ChamarDadosTerc
     {
   
            public string Nome;
            public string Cnpj;
            public DateTime Comeco;
            public DateTime Fim;



            public void ListarTerceirizadas(int id)
            {
                string query = "Select * from tb_terceirizado where id_terc = @id_terc ";

                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("id_terc", id));



                ProjetoDataBase database = new ProjetoDataBase();
                MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);


                while (reader.Read())
                {
                    Nome = reader.GetString("nm_empresa");
                    Cnpj = reader.GetString("ds_cnpj");
                    Comeco = reader.GetDateTime("dt_inicio");
                    Fim = reader.GetDateTime("dt_final");

                }
            reader.Close();

        }

    }
}
