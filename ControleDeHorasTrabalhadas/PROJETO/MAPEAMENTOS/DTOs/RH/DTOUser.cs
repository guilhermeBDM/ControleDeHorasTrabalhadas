using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model
{
   public class DTOUser
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string User  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Cpf { get; set; }
        public DateTime Birth { get; set; }
        public string PostalCode { get; set; }
        public decimal HouseNumber { get; set; }
        public string Telefone { get; set; }

    }
}
