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
    public class SessaoBusiness
    {
        public void InserirSessao(DTOSessao see)
        {
            SessaoDataBase data = new SessaoDataBase();
            if (see.Nome != "" && see.Descricao != "" && see.FaixaEtaria != "" && see.NumeroDeCadeiras > 0)
            {
                data.InserirSessao(see);
                MessageBox.Show("REGISTRADO COM SUCESSO." , "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("PREENCHA TODOS OS CAMPOS.");
        }

        public void AtualizarSessao(DTOSessao see)
        {
            SessaoDataBase data = new SessaoDataBase();
            if (see.IDSessao > 0)
                if (see.Nome != "" && see.Descricao != "" && see.FaixaEtaria != "" && see.NumeroDeCadeiras > 0)
                {
                    data.AtualizarSessao(see);
                    MessageBox.Show("REGISTRADO COM SUCESSO.", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("PREENCHA TODOS OS CAMPOS.","TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("OPS! VOCÊ NÃO PODE FAZER ISSO.", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteSessao(int id)
        {
            SessaoDataBase data = new SessaoDataBase();
            data.DeleteSessao(id);
            MessageBox.Show("DELETADO COM SUCESSO.", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<DTOSessao> ListarAll()
        {
            SessaoDataBase data = new SessaoDataBase();
            return data.ListarAll();
        }

        public DTOSessao ListarID(int id)
        {
            SessaoDataBase data = new SessaoDataBase();
            return data.ListarID(id);
        }

    }
}
