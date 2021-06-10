using NSF.TCC.Sundown.DataAccess.QUERYS.CONTABILIDADE;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.CONTABILIDADE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHorasTrabalhadas
{
    public class ContabilidadeBusiness
    {
        public bool Clear { get; set; }
        public void Save(string Motivo, string Operacao, decimal Valor, DateTime Data)
        {
            if (Motivo == string.Empty || Operacao == string.Empty|| Valor == 0)
            {
                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear = false;
                return;
            }
            else
            {
                ContabilidadeDataBase save = new ContabilidadeDataBase();

                // Salvar Transação
                DTOContabilidade ContabilidadeDTO = new DTOContabilidade();

                ContabilidadeDTO.Motivo = Motivo;
                ContabilidadeDTO.Operacao = Operacao;
                ContabilidadeDTO.Valor = Valor;
                ContabilidadeDTO.Data = Data;

                save.SaveTrans(ContabilidadeDTO);

                MessageBox.Show("TRANSAÇÃO SALVA COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear = true;
            }

        }
    }
}
