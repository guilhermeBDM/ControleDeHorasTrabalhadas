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




        //Pegar beneficios
        public void ListBenef(int id)
        {

            string query = "Select * from tb_beneficios where id_usuario = @id_usuario;";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", id));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {

                Transporte = reader.GetBoolean("bt_vt");
                Saude = reader.GetBoolean("bt_plano_saude");
                SalarioFamilia = reader.GetDecimal("nr_sf");
                ValeRefeicao = reader.GetDecimal("vl_vr");
                ValeAlimentacao = reader.GetDecimal("vl_va");
                
            }
            reader.Close();

        }
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




        //Pegar o setor do usuário
        public void ListSetor(int id)
        {

            string query = "Select * from tb_setor where id_usuario = @id_usuario;";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", id));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {

                Setor = reader.GetString("nm_setor");
               


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
        //pegar cargos
        public void ListCargos(int id)
        {

            string query = "Select * from tb_cargos where id_usuario = @id_usuario;";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", id));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {
                Marketing = reader.GetBoolean("bt_marketing");
                RhC = reader.GetBoolean("bt_rh");
                Contabilidade = reader.GetBoolean("bt_contabilidade");
                GerenteLocal = reader.GetBoolean("bt_gerentelocal");
                AGeral = reader.GetBoolean("bt_assistente_geral");
                
            }
            reader.Close();

        }


        //Pegar salário Bruto
        public void ListBrutos(int id)
        {

            string query = "select * from tb_brutos where id_usuario = @id_usuario order by id_brutos desc limit 1";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", id));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {
                IdSalarioBruto = reader.GetInt32("id_brutos");
                SalarioBruto = reader.GetDecimal("vl_salariobruto");
            }
            reader.Close();

        }




    }

}
