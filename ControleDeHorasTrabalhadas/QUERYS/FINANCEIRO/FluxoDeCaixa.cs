using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class FluxoDeCaixa
    {
        public List<ViewFluxo> ListarFluxo(DateTime comeco, DateTime fim,string operacao)
        {
            string query = "select dt_dia,op_operacao,ds_motivo, sum(vl_valor) as vl_valor from vw_fluxo_caixa Where dt_dia >= @comeco and dt_dia <= @fim and op_operacao = @operacao group by dt_dia,op_operacao,ds_motivo order by dt_dia,op_operacao";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("comeco", comeco));
            parameters.Add(new MySqlParameter("fim", fim));
            parameters.Add(new MySqlParameter("operacao", operacao));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query,parameters);

            List<ViewFluxo> itens = new List<ViewFluxo>();

            while (reader.Read())
            {
                ViewFluxo fluxo = new ViewFluxo();
                fluxo.Dia = reader.GetDateTime("dt_dia");
                fluxo.Valor = reader.GetDecimal("vl_valor");
                fluxo.Operacao = reader.GetString("op_operacao");
                fluxo.Motivo = reader.GetString("ds_motivo");

                itens.Add(fluxo);

            }
            reader.Close();

            return itens;
        }

        public List<ViewFluxo> ListFluxoTodos(DateTime comeco, DateTime fim)
        {
            string query = "select dt_dia,op_operacao,ds_motivo, sum(vl_valor) as vl_valor from vw_fluxo_caixa Where dt_dia >= @comeco  and dt_dia <= @fim group by dt_dia,op_operacao,ds_motivo order by dt_dia, op_operacao";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("comeco", comeco));
            parameters.Add(new MySqlParameter("fim", fim));


            ProjetoDataBase database = new ProjetoDataBase();
            MySqlDataReader reader = database.ExecuteSelectParamters(query, parameters);

            List<ViewFluxo> itens = new List<ViewFluxo>();

            while (reader.Read())
            {
                ViewFluxo fluxo = new ViewFluxo();
                fluxo.Dia = reader.GetDateTime("dt_dia");
                fluxo.Valor = reader.GetDecimal("vl_valor");
                fluxo.Operacao = reader.GetString("op_operacao");
                fluxo.Motivo = reader.GetString("ds_motivo");

                itens.Add(fluxo);

            }
            reader.Close();

            return itens;
        }


    }
}
