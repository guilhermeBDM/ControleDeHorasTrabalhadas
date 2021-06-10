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
    public partial class frmConsultarSolicitacoes : Form
    {
        public frmConsultarSolicitacoes()
        {
            InitializeComponent();
        }
        int[] idPontos;
        int[] idPedido;
        int id;

        public frmMenu MenuScreen { get; set; }

        void VoltarMenu()
        {

            this.MenuScreen.popularCbx(id);
            this.Hide();
            this.MenuScreen.Show();

        }

        

        public void getId(int id)
        {
            this.id = id;
            criar.Id = id;
        }
        PontoBusiness dados = new PontoBusiness();
        public void listarPedidos()
        {
            int[] idPontosModif = new int[70];
            int[] idPedidosModif = new int[70];

            int counter = 0;
            gvResults.Rows.Clear();


            foreach (var item in dados.ListarPedidosAlteracao())
            {
                gvResults.Rows.Add(item.Usuario, item.Movimento, item.NovoMovimento, item.Status, item.NovoStatus,item.Motivo);
                idPontosModif[counter] = item.IdPonto;
                idPedidosModif[counter] = item.IdAlteracaoPonto;

                counter++;
            }
            idPontos = idPontosModif;
            idPedido = idPedidosModif;
        }
        private void frmConsultarSolicitacoes_Load(object sender, EventArgs e)
        {

        }
        PontoBusiness criar = new PontoBusiness();
        private void button4_Click(object sender, EventArgs e)
        {
            int idPontoAtual = idPontos[gvResults.SelectedRows[0].Index];
            int idPedidoAlteracaoAtual = idPedido[gvResults.SelectedRows[0].Index];

         
            DateTime horarioDateTime = Convert.ToDateTime(gvResults.SelectedRows[0].Cells[2].Value.ToString());
            string statusGrid = gvResults.SelectedRows[0].Cells[4].Value.ToString();
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

            listarPedidos();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idPedidoAlteracaoAtual = idPedido[gvResults.SelectedRows[0].Index];
            criar.DeletarPedidoAlteracao(idPedidoAlteracaoAtual);
            MessageBox.Show("SOLICITAÇÃO DE ALTERAÇÃO NEGADA COM SUCESSO!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listarPedidos();
        }

        private void frmConsultarSolicitacoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            VoltarMenu();
        }

        private void gvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
