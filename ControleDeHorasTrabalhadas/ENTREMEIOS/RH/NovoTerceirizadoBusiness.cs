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
   public class NovoTerceirizadoBusiness
    {
        public bool Clear;

        public void SaveTerc(string name, string Cnpj, DateTime Inicio, DateTime Final)
        {
            if (name == string.Empty || Cnpj == string.Empty)
            {
                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear = false;
            }
            else
            {
                TerceirizadoDatabase save = new TerceirizadoDatabase();

                // Salvar Parceiro
                DTOTerceirizado TerceiroDTO = new DTOTerceirizado();

                TerceiroDTO.NomeEmpresa = name;
                TerceiroDTO.Cnpj = Cnpj;
                TerceiroDTO.Inicio = Inicio;
                TerceiroDTO.Final = Final;
                

                save.SaveTerc(TerceiroDTO);

                MessageBox.Show("TERCEIRIZADA SALVA COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear = true;

            }

        }
    }
}
