using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class ChamarDadosFornecedores
    {

        public string Nome;
        public string Cnpj;
        public string Fantasia;
        public string Cep;
        public int Numero;


        public void ListarFornecedores(int id)
        {
            string query = "Select * from tb_fornecedor where id_fornecedor = @id_fornecedor ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_fornecedor", id));



            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);


            while (reader.Read())
            {
                Nome = reader.GetString("nm_razao_social");
                Cnpj = reader.GetString("ds_cnpj");
                Fantasia = reader.GetString("nm_fantasia");
                Cep = reader.GetString("ds_cep");
                Numero = reader.GetInt32("ds_numero");
            }
            reader.Close();

        }

    }
}
