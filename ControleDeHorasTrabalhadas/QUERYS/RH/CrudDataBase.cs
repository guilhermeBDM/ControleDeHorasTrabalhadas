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

            string query = "select tb_usuario.id_usuario, tb_usuario.nm_nomedoatendente,tb_usuario.ds_senha,tb_usuario.ds_email,tb_usuario.nm_usuario,tb_usuario.ds_cpf,tb_usuario.dt_nascimento,tb_usuario.ds_cep,tb_usuario.nr_casa,tb_usuario.ds_telefone from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario WHERE tb_demitidos.id_usuario is null";

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
                User.Nome = reader.GetString("nm_nomedoatendente");
                User.Cpf = reader.GetString("ds_cpf");
                User.Birth = reader.GetDateTime("dt_nascimento");
                User.PostalCode = reader.GetString("ds_cep");
                User.HouseNumber = reader.GetDecimal("nr_casa");
                    

                itens.Add(User);
            }
            reader.Close();

            return itens;
        

        }

        public int QuantidadeDeAtivos()
        {

            string query = "select count(*) from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario WHERE tb_demitidos.id_usuario is null ";

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader reader = db.ExecuteSelectParamters(query, null);

            while (reader.Read())
            {
                query = reader.GetString("COUNT(*)");

            }

            int quantidade = Convert.ToInt32(query);
            reader.Close();

            return quantidade;

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


        public int QuantidadeDeDemitidos()
        {

            string query = "select count(*) from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario WHERE tb_demitidos.id_usuario is not null ";

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader reader = db.ExecuteSelectParamters(query, null);

            while (reader.Read())
            {
                query = reader.GetString("COUNT(*)");

            }
            int quantidade = Convert.ToInt32(query);
            reader.Close();

            return quantidade;

        }
        public List<DTOUser> ListAllUsersDemitidos()
        {

            string query = "select tb_usuario.id_usuario, tb_usuario.nm_nomedoatendente,tb_usuario.ds_senha,tb_usuario.ds_email,tb_usuario.nm_usuario,tb_usuario.ds_cpf,tb_usuario.dt_nascimento,tb_usuario.ds_cep,tb_usuario.nr_casa,tb_usuario.ds_telefone from tb_usuario right join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario WHERE tb_demitidos.id_usuario is not null";

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader reader = db.ExecuteSelectParamters(query, null);

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
                User.Nome = reader.GetString("nm_nomedoatendente");
                User.Cpf = reader.GetString("ds_cpf");
                User.Birth = reader.GetDateTime("dt_nascimento");
                User.PostalCode = reader.GetString("ds_cep");
                User.HouseNumber = reader.GetDecimal("nr_casa");


                itens.Add(User);
            }
            reader.Close();

            return itens;


        }



        public int SaveUser(DTOUser User)
        {
            string query = "insert into tb_usuario(nm_nomedoatendente,nm_usuario,ds_email,ds_senha,ds_cpf,dt_nascimento,ds_cep,nr_casa,ds_telefone) VALUES (@nome, @usuario, @email, @senha,@ds_cpf,@dt_nascimento,@ds_cep,@nr_casa,@ds_telefone)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome", User.Nome));
            parameters.Add(new MySqlParameter("usuario",User.User));
            parameters.Add(new MySqlParameter("email",User.Email));
            parameters.Add(new MySqlParameter("senha",User.Password));
            parameters.Add(new MySqlParameter("ds_cpf", User.Cpf));
            parameters.Add(new MySqlParameter("dt_nascimento", User.Birth.ToString("yyyy-MM-dd")));
            parameters.Add(new MySqlParameter("ds_cep", User.PostalCode));
            parameters.Add(new MySqlParameter("nr_casa", User.HouseNumber));
            parameters.Add(new MySqlParameter("ds_telefone", User.Telefone));

            ProjetoDataBase database = new ProjetoDataBase();

            int id = database.ExecuteInsertInt(query,parameters);

            return id;
            

        }
        public void SaveCargo(DTOCargos Cargos)
        {
            string query = "insert into tb_cargos(bt_marketing,bt_contabilidade,bt_rh,bt_gerentelocal,bt_assistente_geral,id_usuario) VALUES (@bt_marketing,@bt_Contabilidade,@bt_rh,@bt_gerentelocal,@bt_assistente_geral,@id_usuario)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("bt_marketing", Cargos.Marketing));
            parameters.Add(new MySqlParameter("bt_contabilidade", Cargos.Contabilidade));
            parameters.Add(new MySqlParameter("bt_rh", Cargos.Rh));
            parameters.Add(new MySqlParameter("bt_gerentelocal", Cargos.GerenteLocal));
            parameters.Add(new MySqlParameter("bt_assistente_geral", Cargos.AGeral));
            parameters.Add(new MySqlParameter("id_usuario", Cargos.IdUser));
     
            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);


        }




        public void SavePermission(DTOPermission Perm)
        {
            string query = "insert into tb_permissao(bt_adm,bt_rh,bt_fin,bt_cont,bt_comp,bt_vend,id_usuario) values (@bt_adm,@bt_rh,@bt_fin,@bt_cont,@bt_comp,@bt_vend,@id_usuario)";


            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("bt_adm", Perm.Administrator));
            parameters.Add(new MySqlParameter("bt_rh", Perm.Rh));
            parameters.Add(new MySqlParameter("bt_fin", Perm.Fin));
            parameters.Add(new MySqlParameter("bt_cont", Perm.Cont));
            parameters.Add(new MySqlParameter("bt_comp", Perm.Comp));
            parameters.Add(new MySqlParameter("bt_vend", Perm.Vend));
            parameters.Add(new MySqlParameter("id_usuario", Perm.IdUser));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query,parameters);

        }
        public void SaveSalarioBruto(DTOSalarioBruto SalBruto)
        {
            string query = "INSERT INTO	tb_brutos(vl_salariobruto,id_usuario) values ( @vl_salariobruto,@id_usuario)";
        

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("vl_salariobruto", SalBruto.SalarioBruto));
            parameters.Add(new MySqlParameter("id_usuario", SalBruto.IdUser));


            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }
        public void SaveSetor(DTOSector setor)
        {
            string query = "insert into tb_setor(nm_setor,id_usuario) values (@nm_setor,@id_usuario)";


            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nm_setor", setor.Setor));
            parameters.Add(new MySqlParameter("id_usuario", setor.IdUsuario));
            

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }
        public void SaveBenef(DTOBenefit beneficios)
        {
            string query = "insert into tb_beneficios(bt_vt,bt_plano_saude,vl_va,vl_vr,nr_sf,id_usuario) values (@bt_vt,@bt_plano_saude,@vl_va,@vl_vr,@nr_sf,@id_usuario)";


            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("bt_vt",beneficios.CommuterBenefits));
            parameters.Add(new MySqlParameter("bt_plano_saude",beneficios.HealthInsurance));
            parameters.Add(new MySqlParameter("vl_va",beneficios.MealVoucher));
            parameters.Add(new MySqlParameter("vl_vr",beneficios.MealTicket));
            parameters.Add(new MySqlParameter("nr_sf",beneficios.FamilySalary));
            parameters.Add(new MySqlParameter("id_usuario", beneficios.IdUsuario));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
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
        public List<DTOUser> ListPorNomeAtendentesDemitidos(string atendente)
        {
            string query = "select tb_usuario.id_usuario,tb_usuario.nm_nomedoatendente,tb_usuario.ds_senha,tb_usuario.ds_email,tb_usuario.nm_usuario,tb_usuario.ds_cpf,tb_usuario.dt_nascimento,tb_usuario.ds_cep,tb_usuario.nr_casa,tb_usuario.ds_telefone from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario WHERE tb_demitidos.id_usuario is not null and(tb_usuario.nm_nomedoatendente like '{0}%')";
            string script = string.Format(query, atendente);


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
        public void UpdateAtendente(DTOUser User)
        {
            string query = "UPDATE tb_usuario SET nm_nomedoatendente = @nm_nomedoatendente,nm_usuario = @nm_usuario,ds_email = @ds_email,dt_nascimento = @dt_nascimento,ds_senha = @ds_senha,ds_cpf = @ds_cpf,ds_cep = @ds_cep,nr_casa = @nr_casa,ds_telefone = @ds_telefone WHERE id_usuario = @id_usuario;";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", User.Id));
            parameters.Add(new MySqlParameter("nm_nomedoatendente", User.Nome));
            parameters.Add(new MySqlParameter("nm_usuario", User.User));
            parameters.Add(new MySqlParameter("ds_email", User.Email));
            parameters.Add(new MySqlParameter("ds_senha", User.Password));
            parameters.Add(new MySqlParameter("ds_cpf", User.Cpf));
            parameters.Add(new MySqlParameter("ds_cep", User.PostalCode));
            parameters.Add(new MySqlParameter("nr_casa", User.HouseNumber));
            parameters.Add(new MySqlParameter("ds_telefone", User.Telefone));
            parameters.Add(new MySqlParameter("dt_nascimento", User.Birth.ToString("yyyy-MM-dd")));


            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query,parameters);

        }
        public void InserirSalarioBruto(DTOSalarioBruto Bruto)
        {
            string query = "insert into tb_brutos(id_usuario,vl_salariobruto) value(@id_usuario,@vl_salariobruto)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", Bruto.IdUser));
            parameters.Add(new MySqlParameter("vl_salariobruto", Bruto.SalarioBruto));
          

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);

        }
        public void UpdateSetor(DTOSector Setor)
        {
            string query = "UPDATE tb_setor SET nm_setor = @nm_setor WHERE id_usuario = @id_usuario;";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_usuario", Setor.IdUsuario));
            parameters.Add(new MySqlParameter("nm_setor", Setor.Setor));


            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);

        }
        public void UpdatePerms(DTOPermission Perm)
        {
            string query = "UPDATE tb_permissao SET bt_adm = @bt_adm,bt_rh = @bt_rh,bt_fin = @bt_fin,bt_cont = @bt_cont,bt_comp = @bt_comp,bt_vend = @bt_vend WHERE id_usuario = @id_usuario";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("bt_adm", Perm.Administrator));
            parameters.Add(new MySqlParameter("bt_rh", Perm.Rh));
            parameters.Add(new MySqlParameter("bt_fin", Perm.Fin));
            parameters.Add(new MySqlParameter("bt_cont", Perm.Cont));
            parameters.Add(new MySqlParameter("bt_comp", Perm.Comp));
            parameters.Add(new MySqlParameter("bt_vend", Perm.Vend));
            parameters.Add(new MySqlParameter("id_usuario", Perm.IdUser));


            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);

        }

        public void UpdateCargos(DTOCargos Cargos)
        {
            string query = "UPDATE tb_cargos SET bt_marketing = @bt_marketing,bt_contabilidade = @bt_contabilidade,bt_rh = @bt_rh,bt_gerentelocal = @bt_gerentelocal,bt_assistente_geral = @bt_assistente_geral WHERE id_usuario = @id_usuario";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("bt_marketing", Cargos.Marketing));
            parameters.Add(new MySqlParameter("bt_contabilidade", Cargos.Contabilidade));
            parameters.Add(new MySqlParameter("bt_rh", Cargos.Rh));
            parameters.Add(new MySqlParameter("bt_gerentelocal", Cargos.GerenteLocal));
            parameters.Add(new MySqlParameter("bt_assistente_geral", Cargos.AGeral));
            parameters.Add(new MySqlParameter("id_usuario", Cargos.IdUser));


            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);

        }

       

    

        public List<DTOUser> ListarAtivos()
        {
            string script = "select tb_usuario.id_usuario, tb_usuario.nm_nomedoatendente,tb_demitidos.id_demitidos from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario  WHERE tb_demitidos.id_usuario is null";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(script, null);

            List<DTOUser> usuariosativos = new List<DTOUser>();
            while (reader.Read() == true)
            {
                DTOUser User = new DTOUser();
                User.Id = reader.GetInt32("id_usuario");
                User.Nome = reader.GetString("nm_nomedoatendente");


                usuariosativos.Add(User);
            }
            reader.Close();

            return usuariosativos;
        }
        public List<DTOUser> ListarDemitidos()
        {
            string script = "select tb_usuario.id_usuario, tb_usuario.nm_nomedoatendente,tb_demitidos.id_demitidos from tb_usuario left join tb_demitidos on tb_usuario.id_usuario = tb_demitidos.id_usuario  WHERE tb_demitidos.id_usuario is not null";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(script, null);

            List<DTOUser> usuariosativos = new List<DTOUser>();
            while (reader.Read() == true)
            {
                DTOUser User = new DTOUser();
                User.Id = reader.GetInt32("id_usuario");
                User.Nome = reader.GetString("nm_nomedoatendente");


                usuariosativos.Add(User);
            }
            reader.Close();

            return usuariosativos;
        }
       


        public List<DTOParceiros> ListarParceiros()
        {
            string query = "Select * from tb_parceiro";

            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);

            List<DTOParceiros> itens = new List<DTOParceiros>();

            while(reader.Read())
            {
                DTOParceiros part = new DTOParceiros();
                part.IdParceiro = reader.GetInt32("id_parceiro");
                part.NameEnterprise = reader.GetString("nm_empresa");
                part.Cnpj = reader.GetString("ds_cnpj");
                part.Start = reader.GetDateTime("dt_inicio");
                part.End = reader.GetDateTime("dt_final");
                part.Discount = reader.GetString("ds_desconto");
                itens.Add(part);
                
            }
            reader.Close();

            return itens;
        }

        public List<DTOTerceirizado> ListarTerceiros()
        {
            string query = "Select * from tb_terceirizado";
            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelect(query);
            List<DTOTerceirizado> itens = new List<DTOTerceirizado>();
            while (reader.Read())
            {
                DTOTerceirizado terc = new DTOTerceirizado();
                terc.IdTerc = reader.GetInt32("id_terc");
                terc.NomeEmpresa = reader.GetString("nm_empresa");
                terc.Cnpj = reader.GetString("ds_cnpj");
                terc.Inicio = reader.GetDateTime("dt_inicio");
                terc.Final = reader.GetDateTime("dt_final");
                itens.Add(terc);
            }
            reader.Close();

            return itens;
        }
      
    }
}
