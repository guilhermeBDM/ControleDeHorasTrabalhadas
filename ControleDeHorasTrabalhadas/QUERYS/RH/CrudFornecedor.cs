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
    public class CrudFornecedor
    {
        public void SaveFornecedor(DTOFornecedor fornecedores)
        {
            string query = "insert into tb_fornecedor(nm_razao_social,nm_fantasia,ds_cnpj,ds_cep,ds_numero) VALUES (@nm_razao_social,@nm_fantasia,@ds_cnpj,@ds_cep,@ds_numero)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nm_razao_social", fornecedores.RazãoSocial));
            parameters.Add(new MySqlParameter("nm_fantasia", fornecedores.NomeFantasia));
            parameters.Add(new MySqlParameter("ds_cnpj", fornecedores.Cnpj));
            parameters.Add(new MySqlParameter("ds_cep", fornecedores.CodigoPostal));
            parameters.Add(new MySqlParameter("ds_numero", fornecedores.Numero));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);




        }

        public List<DTOFornecedor> ListarFornecedores()
        {
            string query = "Select * from tb_fornecedor";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            List<DTOFornecedor> itens = new List<DTOFornecedor>();

            while (reader.Read())
            {
                DTOFornecedor fornc = new DTOFornecedor();
                fornc.IdForncedor = reader.GetInt32("id_fornecedor");
                fornc.RazãoSocial = reader.GetString("nm_razao_social");
                fornc.NomeFantasia = reader.GetString("nm_fantasia");
                fornc.Cnpj = reader.GetString("ds_cnpj");
                fornc.CodigoPostal = reader.GetString("ds_cep");
                fornc.Numero = reader.GetInt32("ds_numero");
                itens.Add(fornc);

            }
            reader.Close();

            return itens;
        }

        public List<DTOFornecedor> ListarPorFornecedor(string fornecedor)
        {
            string query = "select * from tb_fornecedor WHERE  nm_razao_social like '{0}%'";
            string script = string.Format(query, fornecedor);


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(script);

            List<DTOFornecedor> itens = new List<DTOFornecedor>();

            while (reader.Read())
            {

                DTOFornecedor fornc = new DTOFornecedor();
                fornc.IdForncedor = reader.GetInt32("id_fornecedor");
                fornc.RazãoSocial = reader.GetString("nm_razao_social");
                fornc.NomeFantasia = reader.GetString("nm_fantasia");
                fornc.Cnpj = reader.GetString("ds_cnpj");
                fornc.CodigoPostal = reader.GetString("ds_cep");
                fornc.Numero = reader.GetInt32("ds_numero");
                itens.Add(fornc);

            }
            reader.Close();

            return itens;
        }
    }
}
