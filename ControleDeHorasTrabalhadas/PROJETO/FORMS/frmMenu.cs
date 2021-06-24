using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using NSF.TCC.Sundown.Model.DTOs;
using ControleDeHorasTrabalhadas.FORMS;
using NSF.TCC.Sundown.Model;

namespace ControleDeHorasTrabalhadas
{
    public partial class frmMenu : Form
    {
        
        public frmMenu()
        {
            InitializeComponent();
            
        }
       
        private void frmMenu_Load(object sender, EventArgs e)
        {
            cbxStatus.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public bool close;
        public DTOPermission permGuardID { get; set; }
        int id;

        public void permAcc(DTOPermission a)
        {
            PontoBusiness criar = new PontoBusiness();
            
            this.permGuardID = a;
            id = a.IdUser;
            DTOUser user = criar.ListAllDadosUser(id);

            lblNome.Text = user.Nome;

            if (a.Administrator || a.Administrator)
            {
                aToolStripMenuItem.Visible = true;
                menuStrip1.Padding = new Padding(115, 2, 0, 2);
            }
            else
            {

                
                aToolStripMenuItem.Visible = false;
                menuStrip1.Padding = new Padding(125, 2, 0, 2);


            }

        }
        public void popularCbx(int id)
        {
            cbxStatus.Items.Clear();
            PontoBusiness criar = new PontoBusiness();

            criar.Id = id;
            List<string> lista = criar.SelectItem();
            lista.Insert(0, "ESCOLHA UM STATUS");

            foreach (var item in lista)
            {
                cbxStatus.Items.Add(item);
            }
            cbxStatus.SelectedIndex = 0;

        }


        private void button2_Click(object sender, EventArgs e)
        {

            frmConsultarPontos tela = new frmConsultarPontos();
            tela.MenuScreen = this;
            tela.getId(id);
            tela.Show();
            tela.Listar();
            tela.listarPontos();
            this.Hide();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            frmConsultarSolicitacoes tela = new frmConsultarSolicitacoes();
            tela.MenuScreen = this;
            tela.getId(id);
            tela.Show();
            tela.listarPedidos();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (cbxStatus.SelectedItem.ToString() != "ESCOLHA UM STATUS")
            {
                frmConfirmacao conf = new frmConfirmacao();
                conf.MenuScreen = this;
                conf.setDados(lblHorario.Text, lblDiaSemana.Text, cbxStatus.Text);
                conf.getId(id);
              
                conf.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("ESCOLHA UM STATUS PARA REGISTRAR.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string[] meses = {"Janeiro", "Fevereiro", "Março", "Abril", "Maio",
    "Junho", "Julho", "Setembro", "Outubro", "Novembro", "Dezembro"};
        string[] dias = {"Segunda", "Terça", "Quarta", "Quinta", "Sexta",
    "Sábado", "Domingo"};

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHorario.Text = DateTime.Now.ToLongTimeString();
            timerHorario.Interval = 500;
            


            var date = DateTime.Now;
            var hora = date.Hour;
            var mes = date.Month;
            var dia = date.Day;
            int diaSemana = (int)date.DayOfWeek;

            string nomeMes = meses[mes - 1];
            string nomeDia = dias[diaSemana - 1];
            lblDiaSemana.Text = nomeDia + ", " + dia + " de " + nomeMes;
            //lblDiaSemana.Text = "Sábado, 27 de dezembro";


            if (hora >= 6 && hora < 12)
            {
                lblSaudacao.Location = new Point(128, 27);
                lblSaudacao.Text = "Bom dia,";
                
            }
            else if (hora >= 12 && hora < 18)
            {
                lblSaudacao.Location = new Point(122, 27);
                lblSaudacao.Text = "Boa tarde,";

            }
            else if (hora >= 18 || hora < 6)
            {
                lblSaudacao.Location = new Point(119, 27);

                lblSaudacao.Text = "Boa noite,";

            }
    
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void lblHorario_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Location = new Point(0, 12);
            tableLayoutPanel4.Visible = true;
            tableLayoutPanel2.Location = new Point(0, 90);

            cbxStatus.Enabled = true;
            timerHorario.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            timerHorario.Enabled = true;
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
            
        }

        private void timerCxb_Tick(object sender, EventArgs e)
        {
            popularCbx(id);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frmConsultarPontoFuncionarios tela = new frmConsultarPontoFuncionarios();
            tela.MenuScreen = this;

            tela.Show();
            tela.Listar();

            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmConsultarPontos tela = new frmConsultarPontos();
            tela.MenuScreen = this;
            tela.getId(id);
            tela.Show();
            tela.Listar();
            tela.listarPontos();
            this.Hide();
        }

        private void cONSULTARSOLICITAÇÕESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarSolicitacoes tela = new frmConsultarSolicitacoes();
            tela.MenuScreen = this;
            tela.getId(id);
            tela.Show();
            tela.listarPedidos();
            this.Hide();
        }

        private void cONSULTARPONTOSDEFUNCIONÁRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarPontoFuncionarios tela = new frmConsultarPontoFuncionarios();
            tela.MenuScreen = this;

            tela.Show();
            tela.Listar();

            this.Hide();
        }
    }
}
