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
    public partial class frmConsultarPontos : Form
    {
        public frmConsultarPontos()
        {
            InitializeComponent();
        }
        PontoBusiness dados = new PontoBusiness();
        public frmMenu MenuScreen { get; set; }

        void VoltarMenu()
        {
            this.Hide();
            this.MenuScreen.Show();
            
        }
        public void Listar()
        {



            dtpData.Value = DateTime.Now;
            dtpData.Visible = true;
        }

        
        private void frmConsultarPontos_Load(object sender, EventArgs e)
        {

        }
        int id;
        public void getId(int id)
        {
            this.id = id;
        }
        int[] idPontos;
        public void listarPontos()
        {
            int[] idPontosModif = new int[30];
            int counter = 0;
            gvResults.Rows.Clear();
           

           foreach (var item in dados.ListarPonto(id, dtpData.Value.ToString("yyyy-MM-dd")))
           {
                gvResults.Rows.Add(item.Movement,item.Status,"Rua XPTO, 28. São Paulo, SP");
                idPontosModif[counter] = item.Id;
                counter++;
           }
           idPontos = idPontosModif;

            if (gvResults.RowCount == 0)
            {
                button4.Enabled = false;
            }
            else 
            {
                button4.Enabled = true;

            }
        }
        private void lbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void lbxPontos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
                listarPontos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int idPontoAtual = idPontos[gvResults.SelectedRows[0].Index];
            frmSolicitarAlteracaoPonto frm = new frmSolicitarAlteracaoPonto();
            frm.getDados(idPontoAtual, gvResults.SelectedRows[0].Cells[0].Value.ToString(), gvResults.SelectedRows[0].Cells[1].Value.ToString());
            frm.consultaPontosScreen = this;
            frm.Show();
            this.Hide();
        }

        private void frmConsultarPontos_FormClosing(object sender, FormClosingEventArgs e)
        {
            VoltarMenu();
        }
    }
}
