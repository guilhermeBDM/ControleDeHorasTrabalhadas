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
    public class DemitirInsert
    {
        public void Demitir(DTODemitidos demitidos)
        {
            string query = "insert into tb_demitidos(nm_nomedoatendente,nm_setor,ds_causa,dt_dia_demissao,id_usuario) values(@nome,@setor,@causa,@dia_demissao,@idUsuario)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@nome", demitidos.Nome));
            parameters.Add(new MySqlParameter("@setor", demitidos.Setor));
            parameters.Add(new MySqlParameter("@causa", demitidos.Causa));
            parameters.Add(new MySqlParameter("@dia_demissao", demitidos.Dia.ToString("yyyy-MM-dd")));
            parameters.Add(new MySqlParameter("@idUsuario", demitidos.IdUsuarios));

            ProjetoDataBase database = new ProjetoDataBase();

            database.ExecuteInsertParamters(query, parameters);
                       

        }
    }
}
