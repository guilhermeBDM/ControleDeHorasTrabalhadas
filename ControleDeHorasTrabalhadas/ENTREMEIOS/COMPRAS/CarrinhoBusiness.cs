using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class CarrinhoBusiness
    {

        public bool Clear { get; set; }

        public string CadastraPedido(DTOPedido pedido, List<DTOPedidoItem> listaItem)
        {
            CarrinhoDataBase db = new CarrinhoDataBase();


            int idPedidoRecuperado = db.CriarCarrinho(pedido.IdForncedor, pedido.DtPedido, pedido.DsPedido,pedido.Total);

            foreach (var item in listaItem)
            {
                db.AddProdutoItem(idPedidoRecuperado, item.NomeProduto,item.ValorProduto,item.Quantidade);

            }
            Clear = true;

            return "PEDIDO REGISTRADO COM SUCESSO.";


        }

        public List<DTOFornecedor> ListarFornecedores()
        {
            CarrinhoDataBase db = new CarrinhoDataBase();
            return db.ListarFornecedores();
        }
    }
}
