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
    public class Demitir
    {
        public bool Clear { get; set; }

        public void DemitirFuncionario(string nome, string setor, string causa, DateTime data, int idUser)
        {
            if (causa == string.Empty)
            {

                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear = false;
            }
            else
            {


                DemitirInsert SaveDB = new DemitirInsert();

                // Demitir o usuário
                DTODemitidos demitidosDTO = new DTODemitidos();
                demitidosDTO.Nome = nome;
                demitidosDTO.Setor = setor;
                demitidosDTO.Causa = causa;
                demitidosDTO.Dia = data;
                demitidosDTO.IdUsuarios = idUser;



                SaveDB.Demitir(demitidosDTO);


                MessageBox.Show("NOVA DEMISSÃO REALIZADA!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear = true;



            }
        }
    }
}
