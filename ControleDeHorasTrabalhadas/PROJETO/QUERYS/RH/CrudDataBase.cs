using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class CrudDataBase
    {
        public int Id { get; set; }

        public List<DTOUser> ListAllUsers()
        {

            string query = "select tb_usuario.id_usuario, tb_usuario.nm_nome,tb_usuario.ds_senha,tb_usuario.ds_email,tb_usuario.nm_usuario,tb_usuario.ds_cpf,tb_usuario.dt_nascimento,tb_usuario.ds_cep,tb_usuario.nr_casa,tb_usuario.ds_telefone from tb_usuario";

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader reader = db.ExecuteSelectParamters(query,null);

            List<DTOUser> itens = new List<DTOUser>();

            DTOUser User = null;

            while (reader.Read())
            {
                User = new DTOUser();
                                               
                User.Id = reader.GetInt32("id_usuario");
                User.User = reader.GetString("nm_usuario");
                User.Password = reader.GetString("ds_senha");
                User.Telefone = reader.GetString("ds_telefone");

                User.Email = reader.GetString("ds_email");
                User.Nome = reader.GetString("nm_nome");
                User.Cpf = reader.GetString("ds_cpf");
                User.Birth = reader.GetDateTime("dt_nascimento");
                User.PostalCode = reader.GetString("ds_cep");
                User.HouseNumber = reader.GetDecimal("nr_casa");
                    

                itens.Add(User);
            }
            reader.Close();

            return itens;
        

        }

      
        
        public int ValidacaoCpf(string cpf)
        {

            string query = "select count(*) from tb_usuario left join tb_demitidos " +
                            "on tb_usuario.id_usuario = tb_demitidos.id_usuario" +
                              " WHERE tb_demitidos.id_usuario is null and ds_cpf = @ds_cpf";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("ds_cpf", cpf));

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader reader = db.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {
                query = reader.GetString("count(*)");

            }

            int quantidade = Convert.ToInt32(query);
            reader.Close();

            return quantidade;

        }
        public int ValidacaoEmail(string email)
        {

            string query = "select count(*) from tb_usuario left join tb_demitidos " +
                            "on tb_usuario.id_usuario = tb_demitidos.id_usuario" +
                              " WHERE tb_demitidos.id_usuario is null and ds_email = @ds_email";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("ds_email", email));

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader reader = db.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {
                query = reader.GetString("count(*)");

            }

            int quantidade = Convert.ToInt32(query);
            reader.Close();

            return quantidade;

        }


       


      




    


        public List<DTOUser> ListPorNomeAtendente(string atendente)
        {
            string query = "select tb_usuario.id_usuario,tb_usuario.nm_nomedoatendente,tb_usuario.ds_senha,tb_usuario.ds_email,tb_usuario.nm_usuario,tb_usuario.ds_cpf,tb_usuario.dt_nascimento,tb_usuario.ds_cep,tb_usuario.nr_casa,tb_usuario.ds_telefone from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario WHERE tb_demitidos.id_usuario is null and(tb_usuario.nm_nomedoatendente like '{0}%')";
            string script = string.Format(query,atendente);
                      

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(script);

            List<DTOUser> itens = new List<DTOUser>();

            while (reader.Read())
            {

                DTOUser User = new DTOUser();

                User.Id = reader.GetInt32("id_usuario");
                User.User = reader.GetString("nm_usuario");
                User.Password = reader.GetString("ds_senha");

                User.Email = reader.GetString("ds_email");
                User.Nome = reader.GetString("nm_nomedoatendente");
                User.Cpf = reader.GetString("ds_cpf");
                User.Birth = reader.GetDateTime("dt_nascimento");
                User.PostalCode = reader.GetString("ds_cep");
                User.HouseNumber = reader.GetDecimal("nr_casa");
                User.Telefone = reader.GetString("ds_telefone");




                itens.Add(User);

            }
            reader.Close();

            return itens;
        }
    
    

    

       

    

   
      
      
    }
}
