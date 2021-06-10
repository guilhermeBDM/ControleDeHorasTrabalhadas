using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class FluxoDeCaixaB
    {
        public List<ViewFluxo> ListAll(DateTime comeco, DateTime fim,string operacao)
        {

            FluxoDeCaixa db = new FluxoDeCaixa();
            List<ViewFluxo> fluxo = db.ListarFluxo(comeco,fim,operacao);

            return fluxo;
        }

        public List<ViewFluxo> ListAllT(DateTime comeco, DateTime fim)
        {

            FluxoDeCaixa db = new FluxoDeCaixa();
            List<ViewFluxo> fluxo = db.ListFluxoTodos(comeco, fim);

            return fluxo;
        }

    }
}
