using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class FuncionarioDoMesDataBase
    {
        public MemoryStream Mstream;
        public string Nome;
        public string Parabenizacao;
        

        public void SaveFuncDoMes(DTOFuncionarioDoMes funcmes)
        {
            string query = "Insert into tb_funcionariomes (ds_nomedofunc, ft_imagemdofunc, ds_parabenizacao)values (@ds_nomedofunc,@ft_imagemdofunc,@ds_parabenizacao)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("ds_nomedofunc", funcmes.Nome));
            parameters.Add(new MySqlParameter("ft_imagemdofunc", funcmes.Foto));
            parameters.Add(new MySqlParameter("ds_parabenizacao", funcmes.parabenizacao));
                      
            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);


        }


        public int IdMaximo()
        {

            string query = "SELECT IFNULL(MAX(id_funcmes), 0) from tb_funcionariomes";

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader reader = db.ExecuteSelectParamters(query, null);
            int quantidade = 0;

            while (reader.Read())
            {
                query = reader.GetString("IFNULL(MAX(id_funcmes), 0)");

            }

         
                quantidade = Convert.ToInt32(query);
            reader.Close();

            return quantidade;
            
           

        }


        public void ChamarFoto(int id)
        {
            string query = "Select * from tb_funcionariomes where id_funcmes = @id_funcmes";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_funcmes", id));
          
            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            while (reader.Read())
            {

                byte[] imagem = (byte[])(reader["ft_imagemdofunc"]);
                MemoryStream mstream = new MemoryStream(imagem);
                //pbImagem.Image = System.Drawing.Image.FromStream(mstream);
                Mstream = mstream;




            }
            reader.Close();



        }
        public void ListFuncMes(int id)
        {
            string query = "Select * from tb_funcionariomes where id_funcmes = @id_funcmes";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_funcmes", id));
            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query,parameters);


            while (reader.Read())
            {
                Nome = reader.GetString("ds_nomedofunc");
                Parabenizacao = reader.GetString("ds_parabenizacao");
              

            }
            reader.Close();

        }


    }
}
