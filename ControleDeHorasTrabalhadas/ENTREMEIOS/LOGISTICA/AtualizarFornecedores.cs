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
    public class AtualizarFornecedores
    {
        public bool Clear { get; set; }

        public void Alterar(int id, string nome, string cnpj, string fantasia, string cep, int numero)
        {
            if (nome == string.Empty || cnpj == string.Empty || fantasia == string.Empty || cep == string.Empty || numero == 0)
            {

                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear = false;
            }
            else
            {

                CrudDataBase AttDb = new CrudDataBase();

                // Salvar o usuário
                DTOFornecedor fornecedorDTO = new DTOFornecedor();

                fornecedorDTO.IdForncedor = id;
                fornecedorDTO.CodigoPostal = cep;
                fornecedorDTO.Cnpj = cnpj;
                fornecedorDTO.Numero = numero;
                fornecedorDTO.RazãoSocial = nome;
                fornecedorDTO.NomeFantasia = fantasia;


                AttDb.UpdateForn(fornecedorDTO);

                MessageBox.Show("NOVA ATUALIZAÇÃO REALIZADA!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear = true;


            }
        }
    }
}
