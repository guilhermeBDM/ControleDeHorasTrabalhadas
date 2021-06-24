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
    public partial class frmMensagemDevolutiva : Form
    {
        public frmMensagemDevolutiva()
        {
            InitializeComponent();
        }

        public frmConsultarSolicitacoes solicitacoesScreen  { get; set; }

        int idPontoAtual;
        int idPedidoAlteracaoAtual;
        DateTime horarioDateTime;
        string statusGrid;
        int tela;
        public void setDados(int idPontoAtual, int idPedidoAlteracaoAtual, DateTime horarioDateTime, string statusGrid, int tela)
        {
            this.idPontoAtual = idPontoAtual;
            this.idPedidoAlteracaoAtual = idPedidoAlteracaoAtual;
            this.horarioDateTime = horarioDateTime;
            this.statusGrid=  statusGrid;
            this.tela = tela;
        }

        public void setDados(int idPedidoAlteracaoAtual,int tela)
        {
            this.idPedidoAlteracaoAtual = idPedidoAlteracaoAtual;
            this.tela = tela;
        }
        void VoltarSolicitacoes()
        {

            this.solicitacoesScreen.listarPedidos();
            this.Hide();
            this.solicitacoesScreen.Show();

        }
        PontoBusiness criar = new PontoBusiness();

        private void button4_Click(object sender, EventArgs e)
        {
            if (tela == 1)
            {
                if (statusGrid != "CANCELAR")
                {
                    criar.AlterarPonto(idPontoAtual, horarioDateTime.ToString("yyyy-MM-dd HH:mm:ss"), statusGrid);
                    criar.DeletarPedidoAlteracao(idPedidoAlteracaoAtual);

                }
                else
                {
                    criar.DeletarPedidoAlteracao(idPedidoAlteracaoAtual);
                    criar.DeletarPonto(idPontoAtual);
                }
                MessageBox.Show("SOLICITAÇÃO DE ALTERAÇÃO PERMITIDA COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                criar.DeletarPedidoAlteracao(idPedidoAlteracaoAtual);
                MessageBox.Show("SOLICITAÇÃO DE ALTERAÇÃO NEGADA COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            VoltarSolicitacoes();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VoltarSolicitacoes();
        }

        private void frmMensagemDevolutiva_Load(object sender, EventArgs e)
        {

        }
    }
}
