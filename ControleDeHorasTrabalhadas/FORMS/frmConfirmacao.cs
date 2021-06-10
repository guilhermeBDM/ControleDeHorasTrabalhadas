using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHorasTrabalhadas
{
    public partial class frmConfirmacao : Form
    {
        public frmConfirmacao()
        {
            InitializeComponent();
        }

        public frmMenu MenuScreen { get; set; }
        PontoBusiness criar = new PontoBusiness();
        int id;
        
        public void getId(int id)
        {
            this.id = id;
            criar.Id = id;
        }
        public void setDados(string hora,string data,string movimento)
        {
            lblHorario.Text = hora;
            lblDiaSemana.Text = data;
            lblMovimento.Text = movimento;
        }
        private void lblHorario_Click(object sender, EventArgs e)
        {

        }

        private void lblSaudacao_Click(object sender, EventArgs e)
        {

        }

        void VoltarMenu()
        {
            this.MenuScreen.popularCbx(id);
            this.MenuScreen.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmConfirmacao_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            criar.CriarPonto(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), lblMovimento.Text);

            MessageBox.Show("PONTO REGISTRADO COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            VoltarMenu();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            VoltarMenu();
         
        }

        private void frmConfirmacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            VoltarMenu();
        }
    }
}
