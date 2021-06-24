using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class ListarFuncionariosAtivos
    {

     public List<DTOUser> ListAll()
     {
       CrudDataBase db = new CrudDataBase();
       List<DTOUser> funcionarios = db.ListAllUsers();

       return funcionarios;
     }
         
    }
}
