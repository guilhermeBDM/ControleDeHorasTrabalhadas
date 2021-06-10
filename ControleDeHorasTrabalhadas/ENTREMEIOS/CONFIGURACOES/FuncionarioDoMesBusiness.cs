using NSF.TCC.Sundown.Business;
using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHorasTrabalhadas
{
    public class FuncionarioDoMesBusiness
    {
        public bool Clear { get; set; }
        public bool Visible { get; set; }
        public MemoryStream Mstream;
        public string Nome;
        public string Parabenizacao;

        public void Save(string caminhofoto, string nome, string parabenizacao)
        {
            if (parabenizacao == string.Empty)
            {
                MessageBox.Show("PARABENIZE SEU FUNCIONÁRIO, ELE MERECE!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear = false;
            }
            else
            {

                ConverterImagem c = new ConverterImagem();
                byte[] imgbyte = c.Convert(caminhofoto);



                FuncionarioDoMesDataBase func = new FuncionarioDoMesDataBase();

                DTOFuncionarioDoMes funcionariodomesDTO = new DTOFuncionarioDoMes();

                funcionariodomesDTO.Foto = imgbyte;
                funcionariodomesDTO.Nome = nome;
                funcionariodomesDTO.parabenizacao = parabenizacao;


                func.SaveFuncDoMes(funcionariodomesDTO);

                MessageBox.Show("FUNCIONÁRIO DO MÊS CADASTRADO! PARABÉNS " + nome, "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear = true;
            }
        }

        public void Buscar()
        {
            FuncionarioDoMesDataBase func = new FuncionarioDoMesDataBase();

            int id = func.IdMaximo();

            if (id < 1)
            {
                Visible = false;
            }
            else
            {
                func.ChamarFoto(id);
                Mstream = func.Mstream;

                func.ListFuncMes(id);
                Nome = func.Nome;
                Parabenizacao = func.Parabenizacao;
                Visible = true;
            }



        }



    }
}
