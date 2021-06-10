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
    public class ChamarDadosParceiros
    {
        public string Nome;
        public string Cnpj;
        public DateTime Comeco;
        public DateTime Fim;
        public string Desconto;



        public void ListarParceiros(int id)
        {
            string query = "Select * from tb_parceiro where id_parceiro = @id_parceiro ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_parceiro", id));



            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query,parameters);


            while (reader.Read())
            {
                Nome = reader.GetString("nm_empresa");
                Cnpj = reader.GetString("ds_cnpj");
                Comeco = reader.GetDateTime("dt_inicio");
                Fim = reader.GetDateTime("dt_final");
                Desconto = reader.GetString("ds_desconto");

            }
            reader.Close();

        }
    }
}
