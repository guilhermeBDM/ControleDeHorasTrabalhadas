using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHorasTrabalhadas
{
    public class NovoFornecedor
    {

        public bool Clear { get; set; }

        public void Save(string razaosocial, string nomefantasia, string cnpj, string cep, int numero)
        {
            if (razaosocial == string.Empty || nomefantasia == string.Empty || cnpj == string.Empty || cep == string.Empty || numero == 0)
            {

                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear = false;
            }
          
            else
            {                
                CrudFornecedor SaveDB = new CrudFornecedor();

                // Salvar o fornecedor
                DTOFornecedor fornecedorDTO = new DTOFornecedor();

                fornecedorDTO.RazãoSocial = razaosocial;
                fornecedorDTO.NomeFantasia = nomefantasia;
                fornecedorDTO.Cnpj = cnpj;
                fornecedorDTO.CodigoPostal = cep;
                fornecedorDTO.Numero = numero;
               


                SaveDB.SaveFornecedor(fornecedorDTO);

                MessageBox.Show("NOVO FORNECEDOR CADASTRADO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear = true;

            }



        }


    }
}
