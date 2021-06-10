using NSF.TCC.Sundown.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHorasTrabalhadas.FORMS
{
    public partial class frmConsultaDataEspecifica : Form
    {
        public frmConsultaDataEspecifica()
        {
            InitializeComponent();
        }
        PontoBusiness dados = new PontoBusiness();

        public frmConsultarPontoFuncionarios FuncScreen { get; set; }


        void VoltarTela()
        {
            this.FuncScreen.Show();
            this.Hide();
        }

        public void Listar(DTOUser idUsuario, DateTime data)
        {
            gvResults.Rows.Clear();

            foreach (var item in dados.ListarPonto(idUsuario.Id, data.ToString("yyyy-MM-dd")))
            {
                gvResults.Rows.Add(item.Movement, item.Status, "Rua XPTO, 28. São Paulo, SP");
            }
        }
    
        private void frmConsultaDataEspecifica_Load(object sender, EventArgs e)
        {

        }

        private void frmConsultaDataEspecifica_FormClosing(object sender, FormClosingEventArgs e)
        {
            VoltarTela();
        }

        private void gvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
