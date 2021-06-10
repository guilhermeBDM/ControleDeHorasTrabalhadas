
using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class FiltroBusiness
    {
        public List<DTOUser> Atendentes { get; set; }
        public List<DTOFornecedor> Fornecedores { get; set; }

        public void Filtrar(string texto)
        {
            CrudDataBase Atend = new CrudDataBase();
            Atendentes = Atend.ListPorNomeAtendente(texto);
        }
        public void FiltrarDemitidos(string texto)
        {
            CrudDataBase Atend = new CrudDataBase();
            Atendentes = Atend.ListPorNomeAtendentesDemitidos(texto);

        }

        public void FiltrarFornecedores(string texto)
        {
            CrudFornecedor Forn = new CrudFornecedor();
            Fornecedores = Forn.ListarPorFornecedor(texto);
        }


    }
}
