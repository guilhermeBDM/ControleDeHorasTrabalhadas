using ControleDeHorasTrabalhadas.MAPEAMENTOS.VIEWS.PONTO;
using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{

    public class PontoBusiness
    {
        public int Id { get; set; }
        PontoDataBase db = new PontoDataBase();

        public void CriarPonto(string data, string status)
        { 
                db.CriarPonto(this.Id, data, status);
        }
        public void CriarPedidoAlteracao(int idPonto, string data, string status, string motivo)
        {
            db.CriarPedidoAlteracao(idPonto, data, status, motivo);
        }
        public List<ViewSolicitacoesAlteracaoPonto> ListarPedidosAlteracao()
        {
            return db.ListarPedidosAlteracao();
        }
        public void AlterarPonto(int idPonto, string data, string status)
        {
            db.AlterarPonto(idPonto, data, status);
        }
        public void DeletarPedidoAlteracao(int idAlteracaoPonto)
        {
            db.DeletarPedidoAlteracao(idAlteracaoPonto);
        }
        public void DeletarPonto(int idPonto)
        {
            db.DeletarPonto(idPonto);
        }
        public void Listar(int idPonto, string data, string status, string motivo)
        {
            db.CriarPedidoAlteracao(idPonto, data, status, motivo);
        }
        public List<string> SelectItem()
        {
            DTOPonto baseDados = db.RetornarUltimo(this.Id);
            //string  status = status == "Entrada" && baseDados.Status == "Saida" ? "Entrada" : (status == "Pausa" && (baseDados.Status == "Entrada" || baseDados.Status == "Retorno") ? "Pausa" : (status == "Retorno" && baseDados.Status == "Pausa" ? "Retorno" : (status == "Saída" && baseDados.Status == "Entrada" || baseDados.Status == "Retorno" ? "Saída" : "ERROR")));
            List<string> a = new List<string>();

            if (baseDados.Status == "ENTRADA" || baseDados.Status == "RETORNO")
            {
               
                a.Add("PAUSA");
                a.Add("SAÍDA");
            }
            else if (baseDados.Status == "SAÍDA")
            {
                
                a.Add("ENTRADA");

            }
            else if (baseDados.Status == "PAUSA")
            {

                a.Add("RETORNO");

            }
          

            else if (baseDados.Status == null)
            {

                a.Add("ENTRADA");


            }
            return a;
        }


        public List<DTOUser> ListarUsuarios()
        {
            PontoDataBase dados = new PontoDataBase();
            return dados.ListarUsuarios();
        }
        public DTOUser ListAllDadosUser(int id)
        {
            PontoDataBase dados = new PontoDataBase();
            return dados.ListAllDadosUser(id);
        }

        public List<DTOPonto> ListarPonto(int id, string data)
        {
            PontoDataBase dados = new PontoDataBase();
            return dados.ListarPonto(id, data);
        }

    }
}
