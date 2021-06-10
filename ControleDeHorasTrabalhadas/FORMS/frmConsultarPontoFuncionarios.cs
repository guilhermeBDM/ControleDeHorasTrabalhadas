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
    public partial class frmConsultarPontoFuncionarios : Form
    {
        public frmConsultarPontoFuncionarios()
        {
            InitializeComponent();
        }


        PontoBusiness dados = new PontoBusiness();
        public frmMenu MenuScreen { get; set; }


        void VoltarMenu()
        {
            this.MenuScreen.Show();
            this.Hide();
        }


        
        private void frmConsultarPontoFuncionarios_Load(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            dtpData.Value = DateTime.Now;
            cbxUsuarios.Items.Clear();
            cbxUsuarios.DataSource = dados.ListarUsuarios();
            cbxUsuarios.DisplayMember = "Nome";
            dtpData.Visible = true;


            gvResults.Rows.Add("06/06/2021", "8", "0");
            gvResults.Rows.Add("07/06/2021", "9", "1");
            gvResults.Rows.Add("08/06/2021", "8", "0");
            gvResults.Rows.Add("09/06/2021", "6", "0");
            gvResults.Rows.Add("10/06/2021", "8", "0");




        }

        private void lbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            if (cbxUsuarios.SelectedItem != null)
                cbxUsuarios_SelectedIndexChanged(null, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbxPontos.Items.Clear();
            DTOUser idUsuario = cbxUsuarios.SelectedItem as DTOUser;

            foreach (var item in dados.ListarPonto(idUsuario.Id, dtpData.Value.ToString("yyyy-MM-dd")))
            {
               // lbxPontos.Items.Add("DATA E HORA: " + item.Movement + "  --  STATUS: " + item.Status);
            }
        }

        private void lbxPontos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void gvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void gvResults_DoubleClick(object sender, EventArgs e)
        {

            DTOUser idUsuario = cbxUsuarios.SelectedItem as DTOUser;

            frmConsultaDataEspecifica tela = new frmConsultaDataEspecifica();
            tela.FuncScreen = this;

            tela.Show();
            DateTime horarioDateTime = Convert.ToDateTime(gvResults.SelectedRows[0].Cells[0].Value.ToString());

            tela.Listar(idUsuario, horarioDateTime);
            this.Hide();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmConsultarPontoFuncionarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            VoltarMenu();
        }
    }
}
