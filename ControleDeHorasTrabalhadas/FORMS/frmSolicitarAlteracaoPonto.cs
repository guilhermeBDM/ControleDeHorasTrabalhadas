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
    public partial class frmSolicitarAlteracaoPonto : Form
    {
        public frmSolicitarAlteracaoPonto()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        string horario;
        string movimento;
        int idPonto;
        public void getDados(int idPonto,string horario, string movimento)
        {
            this.horario = horario;
            this.movimento = movimento;
            this.idPonto = idPonto;
            int found = horario.IndexOf(" ");
            txtHorario.Text = horario.Substring(found+1,8);
            cbxStatus.SelectedItem = movimento;
        }
        public frmConsultarPontos consultaPontosScreen { get; set; }

        void VoltarConsulta()
        {
            this.consultaPontosScreen.listarPontos();
            this.consultaPontosScreen.Show();
            this.Hide();
        }


        private void frmSolicitarAlteracaoPonto_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        PontoBusiness criar = new PontoBusiness();

        private void button4_Click(object sender, EventArgs e)
        {
            int found = horario.IndexOf(" ");
            horario = horario.Substring(0,found) + " " + txtHorario.Text;
            DateTime horarioDateTime = Convert.ToDateTime(horario);
            criar.CriarPedidoAlteracao(idPonto, horarioDateTime.ToString("yyyy-MM-dd HH:mm:ss"), cbxStatus.Text,txtMotivo.Text);
            MessageBox.Show("SOLICITAÇÃO DE ALTERAÇÃO REGISTRADA COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            VoltarConsulta();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VoltarConsulta();
        }

        private void frmSolicitarAlteracaoPonto_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void frmSolicitarAlteracaoPonto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
