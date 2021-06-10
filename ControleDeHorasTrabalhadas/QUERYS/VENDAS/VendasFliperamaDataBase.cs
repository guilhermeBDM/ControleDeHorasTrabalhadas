using ControleDeHorasTrabalhadas;
using MySql.Data.MySqlClient;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.VENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.DataAccess.QUERYS.VENDAS
{
    public class VendasFliperamaDataBase
    {

        public void Salvar(DTOIngressoFliperama dados)
        {
            string query = "Insert into tb_ingresso_fliperama(ds_cpf,dt_compra,id_preco_fliperama,nr_fixas) value(@ds_cpf,@dt_compra,@id_preco_fliperama,@nr_fixas)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("ds_cpf", dados.CPF));
            parameters.Add(new MySqlParameter("dt_compra", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new MySqlParameter("id_preco_fliperama", dados.IdPreco));
            parameters.Add(new MySqlParameter("nr_fixas", dados.NumFichas));

            ProjetoDataBase database = new ProjetoDataBase();
            database.ExecuteInsertParamters(query, parameters);
        }

    }
}
