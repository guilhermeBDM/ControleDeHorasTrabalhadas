using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess
{
    public class FolhaPagamentoDataBase
    {
        public List<DTOPonto> ListarHoraExtra(int id, string ultimaData)
        {
            string query;

            if (ultimaData != "0")
            {
                query = "select * from tb_ponto where dt_movimento > '{0}' and id_usuario = {1} and (ds_status = 'Início hora extra' or ds_status = 'Pausa hora extra' or ds_status = 'Retorno hora extra' or ds_status = 'Fim hora extra')";

                query = string.Format(query, (Convert.ToDateTime(ultimaData)).ToString("yyyy-MM-dd HH:mm:ss"), id);
            }
            else
            {

                query = "select * from tb_ponto where id_usuario = {0} and (ds_status = 'Início hora extra' or ds_status = 'Pausa hora extra' or ds_status = 'Retorno hora extra' or ds_status = 'Fim hora extra')";

                query = string.Format(query, id);

            }

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            List<DTOPonto> loop = new List<DTOPonto>();

            while (read.Read())
            {
                DTOPonto reg = new DTOPonto();
                reg.Movement = read.GetString("dt_movimento");
                reg.Status = read.GetString("ds_status");
                loop.Add(reg);
            }
            read.Close();

            return loop;
        }

        public string UltimaDataFolha(int id)
        {
            string query = "select * from tb_folha_de_pagamento where id_usuario = {0} order by id_folha desc limit 1";

            query = string.Format(query, id);

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            if (read.Read())
            {
                return read.GetDateTime("dt_data_ultimo_ponto").ToString("yyyy-MM");
            }
            else {
                return "0";
            }
            read.Close();

        }

        public string UltimaFolha(int id)
        {
            string query = "select * from tb_folha_de_pagamento where id_usuario = {0} order by id_folha desc limit 1";

            query = string.Format(query, id);

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            if (read.Read())
            {
                return read.GetDateTime("dt_data_registro_folha").ToString("yyyy-MM");
            }
            else
            {
                return "0";
            }
            read.Close();

        }

        public void InserirResultado(DTOFolhaDePagamento dados)
        {
            string query = "insert into tb_folha_de_pagamento(id_usuario,id_brutos,nr_faltas,nr_atraso_minutos,vl_hora_extra,vl_salario_liquido,dt_data_ultimo_ponto,dt_data_registro_folha) value({0},{1},{2},{3},{4},{5},'{6}','{7}')";
            query = string.Format(query, dados.IdUsuario, dados.IdSalarioBruto, dados.Falta, dados.AtrasoMinutos, dados.HorasExtras.ToString().Replace(',', '.'),dados.salarioLiquido.ToString().Replace(",", "."), dados.DtDataUltimoPonto.ToString("yyyy-MM-dd HH:mm:ss"), dados.DtDataRegistroFolha.ToString("yyyy-MM-dd"));
            ProjetoDataBase db = new ProjetoDataBase();
            db.ExecuteInsert(query);
        }

        public VOConsultarFolha ConsultaFolha(int id, string data)
        {
            string query = "select * from tb_folha_de_pagamento inner join tb_usuario on tb_folha_de_pagamento.id_usuario = tb_usuario.id_usuario inner join tb_brutos on tb_folha_de_pagamento.id_brutos = tb_brutos.id_brutos inner join tb_beneficios on tb_folha_de_pagamento.id_usuario = tb_beneficios.id_usuario where tb_folha_de_pagamento.id_usuario = {0} and tb_folha_de_pagamento.dt_data_registro_folha = '{1}'";

            query = string.Format(query, id, (Convert.ToDateTime(data)).ToString("yyyy-MM-dd HH:mm:ss"));

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);
            VOConsultarFolha dados = new VOConsultarFolha();

            if (read.Read())
            {
                dados.IdFolha = read.GetInt32("id_folha");
                dados.NomeUsuario = read.GetString("nm_nomedoatendente");
                dados.SalarioBruto = read.GetDecimal("vl_salariobruto");
                dados.ValeTransporte = read.GetBoolean("bt_vt");
                dados.ValeRefeicao = read.GetDecimal("vl_vr");
                dados.ValeAlimentacao = read.GetDecimal("vl_va");
                dados.AssMedica = read.GetBoolean("bt_plano_saude");
                dados.SalarioFamilia = Convert.ToInt32(read.GetInt32("nr_sf"));
                dados.AtrasoMinutos = read.GetInt32("nr_atraso_minutos");
                dados.HoraExtra = read.GetDecimal("vl_hora_extra");
                dados.Falta = read.GetInt32("nr_faltas");
                dados.DataDaFolha = read.GetDateTime("dt_data_registro_folha");
                dados.SalarioLiquido = read.GetDecimal("vl_salario_liquido");

            }
            read.Close();


            return dados;
        }

        public List<string> Data(int id)
        {
            string query = "select * from tb_folha_de_pagamento where id_usuario = {0} order by id_folha desc";
            query = string.Format(query, id);

            ProjetoDataBase db = new ProjetoDataBase();
            MySqlDataReader read = db.ExecuteSelect(query);

            List<string> loop = new List<string>();

            while (read.Read())
            {
                loop.Add(Convert.ToDateTime(read.GetString("dt_data_registro_folha")).ToString("dd-MM-yyyy"));
            }
            read.Close();

            return loop;

        }


    }
}
