using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTO_S.CONFIGURAÇÕES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class VendasBusiness
    {
        InserirValorVendasDataBase metodo = new InserirValorVendasDataBase();

        public void InserirFliperama(decimal valor)
        {
            metodo.InserirFliperama(valor);
        }

        public DTOPrecoIngresso ValorFliperama()
        {
            return metodo.ValorFliperama();
        }

        public void InserirCinema(decimal valor, string periodo)
        {
            metodo.InserirCinema(valor, periodo);
        }

        public DTOPrecoSessao ValorCinema(string periodo)
        {
            return metodo.ValorCinema(periodo);
        }

    }
}
