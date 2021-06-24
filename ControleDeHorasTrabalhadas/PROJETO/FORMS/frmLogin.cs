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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public bool x;
        frmMenu tela = new frmMenu();
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            LoginBusiness logar = new LoginBusiness();
            int perm = logar.Logar(txtEmail.Text, txtSenha.Text);



            if (perm >= 1)
            {
                
                PermissaoBusiness acc = new PermissaoBusiness();
                tela.permAcc(acc.Permin(perm));
                tela.permGuardID = acc.Permin(perm);
                tela.popularCbx(perm);
                MessageBox.Show("COLABORADOR LOGADO COM SUCESSO", "ACESSO PERMITIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tela.Show();


               
                x = true;

                this.Hide();
            }
            else
            {
                MessageBox.Show("COLABORADOR DEMITIDO OU DADOS INCORRETOS!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
