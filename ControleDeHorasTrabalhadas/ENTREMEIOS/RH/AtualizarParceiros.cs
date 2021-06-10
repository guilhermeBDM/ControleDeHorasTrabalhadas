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
    public class AtualizarParceiros
    {
        public bool Clear { get; set; }

        public void Alterar(int id,string nome,string cnpj,string desconto,DateTime inicio,DateTime fim)
        {
            if ((nome == string.Empty || cnpj == string.Empty || desconto == "0"))
            {

                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear = false;
            }
            else
            {

                    CrudDataBase AttDb = new CrudDataBase();

                    // Salvar o usuário
                    DTOParceiros parceirosDTO = new DTOParceiros();

                    parceirosDTO.IdParceiro = id;
                    parceirosDTO.NameEnterprise = nome;
                    parceirosDTO.Cnpj = cnpj;
                    parceirosDTO.Discount = desconto;
                    parceirosDTO.Start = inicio;
                    parceirosDTO.End = fim;
                   

                    AttDb.UpdateParc(parceirosDTO);
                                       
                    MessageBox.Show("NOVA ATUALIZAÇÃO REALIZADA!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear = true;




           
                
            }
        }
    }
}
