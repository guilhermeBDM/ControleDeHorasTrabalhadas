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
    public class ParceiroDatabase
    {
        public void SavePartner(DTOParceiros parceiro)
        {
            string query = "insert into tb_parceiro(id_parceiro, nm_empresa, ds_cnpj, dt_inicio, dt_final, ds_desconto) values(@id_parceiro,@nm_empresa,@ds_cnpj,@dt_inicio,@dt_final,@ds_desconto)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_parceiro", parceiro.IdParceiro));
            parameters.Add(new MySqlParameter("nm_empresa", parceiro.NameEnterprise));
            parameters.Add(new MySqlParameter("ds_cnpj", parceiro.Cnpj));
            parameters.Add(new MySqlParameter("dt_inicio", parceiro.Start.ToString("yyyy-MM-dd")));
            parameters.Add(new MySqlParameter("dt_final", parceiro.End.ToString("yyyy-MM-dd")));
            parameters.Add(new MySqlParameter("ds_desconto", parceiro.Discount));

            ProjetoDataBase projeto = new ProjetoDataBase();

            projeto.ExecuteInsertInt(query, parameters);
        }
    }
}
