using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSF.TCC.Sundown.Business
{
   public class NovoParceiroBusiness
    {
        public bool Clear;

        public void Save(string name , string Cnpj, DateTime Inicio, DateTime Final, string Desconto)
        {
            if (name == string.Empty || Cnpj == string.Empty)
            {
                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear = false;
            }
            else
            {
                ParceiroDatabase save = new ParceiroDatabase();

                // Salvar Parceiro
                DTOParceiros parceiroDTO = new DTOParceiros();

                parceiroDTO.NameEnterprise = name;
                parceiroDTO.Cnpj = Cnpj;
                parceiroDTO.Start = Inicio;
                parceiroDTO.End = Final;
                parceiroDTO.Discount = Desconto;

                save.SavePartner(parceiroDTO);

                MessageBox.Show("PARCEIRO SALVO COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear = true;

            }

        }
    }
}
