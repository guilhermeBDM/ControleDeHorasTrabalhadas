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
    public class TerceirizadoDatabase
    {
        public void SaveTerc(DTOTerceirizado terceiro)
        {
            string query = "insert into tb_terceirizado(id_terc, nm_empresa, ds_cnpj, dt_inicio, dt_final) values(@id_terc, @nm_empresa, @ds_cnpj, @dt_inicio, @dt_final)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_terc", terceiro.IdTerc));
            parameters.Add(new MySqlParameter("nm_empresa", terceiro.NomeEmpresa));
            parameters.Add(new MySqlParameter("ds_cnpj", terceiro.Cnpj));
            parameters.Add(new MySqlParameter("dt_inicio", terceiro.Inicio.ToString("yyyy-MM-dd")));
            parameters.Add(new MySqlParameter("dt_final", terceiro.Final.ToString("yyyy-MM-dd")));


            ProjetoDataBase terceirizado = new ProjetoDataBase();

            terceirizado.ExecuteInsertInt(query, parameters);
        }
    }
}
