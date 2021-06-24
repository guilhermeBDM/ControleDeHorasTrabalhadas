using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class ChamarDados
    {
        //User
        public string Nome;
        public string Cpf;
        public string Cep;
        public string User;
        public string Email;
        public string Password;
        public decimal NumeroCasa;
        public string Telefone;
        public DateTime Nascimento;
        //Setor
        public string Setor;
        //Funções
        public bool Adm;
        public bool Rh;
        public bool Fin;
        public bool Cont;
        public bool Comp;
        public bool Vend;
        //Beneficios
        public bool Transporte;
        public bool Saude;
        public decimal SalarioFamilia;
        public decimal ValeRefeicao;
        public decimal ValeAlimentacao;
        //Salario Bruto
        public int IdSalarioBruto;
        public decimal SalarioBruto;

        //Cargos
        public bool RhC;
        public bool Marketing;
        public bool Contabilidade;
        public bool GerenteLocal;
        public bool AGeral;




        
        //Dados da tabela de usuario
        public void ListAllDadosUser(int id)
        {

            string query = "Select * from tb_usuario where id_usuario = @id_usuario;";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", id));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query,parameters);

            while (reader.Read())
            {

                Nome = reader.GetString("nm_nomedoatendente");
                Cpf = reader.GetString("ds_cpf");
                Cep = reader.GetString("ds_cep");
                User = reader.GetString("nm_usuario");
                Email = reader.GetString("ds_email");
                Password = reader.GetString("ds_senha");
                NumeroCasa = reader.GetDecimal("nr_casa");
                Telefone = reader.GetString("ds_telefone");
                Nascimento = reader.GetDateTime("dt_nascimento");
            }
            reader.Close();

        }




        

        //Pegar permissões
        public void ListPerms(int id)
        {

            string query = "Select * from tb_permissao where id_usuario = @id_usuario;";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", id));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {
                Adm = reader.GetBoolean("bt_adm");
                Rh = reader.GetBoolean("bt_rh");
                Fin = reader.GetBoolean("bt_fin");
                Cont = reader.GetBoolean("bt_cont");
                Comp = reader.GetBoolean("bt_comp");
                Vend = reader.GetBoolean("bt_vend");
            }
            reader.Close();

        }
       






    }

}
