using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class BuscarAtendenteBusiness
    {

        public List<DTOUser> Buscar()
        {
            CrudDataBase AtendenteDatabas = new CrudDataBase();
            List<DTOUser> Atendentes = AtendenteDatabas.ListAllUsers();
            return Atendentes;
        }
        public int Quantidade()
        {
            CrudDataBase AtendenteDatabas = new CrudDataBase();
            int quantidade = AtendenteDatabas.QuantidadeDeAtivos();
            return quantidade;
        }
        public int QuantidadeDeDemitidos()
        {
            CrudDataBase AtendenteDatabas = new CrudDataBase();
            int quantidade = AtendenteDatabas.QuantidadeDeDemitidos();
            return quantidade;
        }
        public List<DTOUser> BuscarDemitidos()
        {
            CrudDataBase AtendenteDatabas = new CrudDataBase();
            List<DTOUser> Atendentes = AtendenteDatabas.ListAllUsersDemitidos();
            return Atendentes;
        }


    }
}
