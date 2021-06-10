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
    public  class AtualizarTerceirizadas
    {
        public bool Clear { get; set; }

        public void Alterar(int id, string nome, string cnpj,DateTime inicio, DateTime fim)
        {
            if ((nome == string.Empty || cnpj == string.Empty))
            {

                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear = false;
            }
            else
            {

                CrudDataBase AttDb = new CrudDataBase();

                // Salvar o usuário
                DTOTerceirizado terceirizadosDTO = new DTOTerceirizado();

                terceirizadosDTO.IdTerc = id;
                terceirizadosDTO.NomeEmpresa = nome;
                terceirizadosDTO.Cnpj = cnpj;
                terceirizadosDTO.Inicio = inicio;
                terceirizadosDTO.Final = inicio;


                AttDb.UpadateTerc(terceirizadosDTO);

                MessageBox.Show("NOVA ATUALIZAÇÃO REALIZADA!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear = true;






            }
        }
    }
}
