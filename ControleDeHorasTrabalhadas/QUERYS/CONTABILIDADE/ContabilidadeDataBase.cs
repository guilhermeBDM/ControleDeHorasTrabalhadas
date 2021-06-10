using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.CONTABILIDADE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess.QUERYS.CONTABILIDADE
{
    public class ContabilidadeDataBase
    {
        public void SaveTrans(DTOContabilidade contabilidade)
        {
            string query = "insert into tb_contabilidade(ds_motivo,op_operacao,vl_valor,dt_data_da_transacao) VALUES (@ds_motivo,@op_operacao,@vl_valor,@dt_data_da_transacao)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("ds_motivo", contabilidade.Motivo));
            parameters.Add(new MySqlParameter("op_operacao", contabilidade.Operacao));
            parameters.Add(new MySqlParameter("vl_valor", contabilidade.Valor));
            parameters.Add(new MySqlParameter("dt_data_da_transacao", contabilidade.Data.ToString("yyyy-MM-dd")));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
            
        }

    }
}
