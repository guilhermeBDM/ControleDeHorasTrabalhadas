using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Model.DTOs
{
    public class DTOBenefit
    {
     public int IdBeneficios { get; set; }
     public int IdUsuario { get; set; }
     public bool CommuterBenefits { get; set; }
     public bool HealthInsurance { get; set; }
     public decimal FamilySalary { get; set; }
     public decimal MealTicket { get; set; }
     public decimal MealVoucher { get; set; }


    }
}
