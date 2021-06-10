using NSF.TCC.Sundown.DataAccess.QUERYS.VENDAS;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTO_S.VENDAS;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.VENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSF.TCC.Sundown.Business.ENTREMEIOS.VENDAS
{
    public class VendaIngressoBusiness
    {

        VendaIngressoDataBase metodos = new VendaIngressoDataBase();

        public List<ViewsVendasIngresso> Filmes()
        {
            return metodos.Filmes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public DTOPrecoSessao CalcularPreco(string data, int numeroDeCadeiras)
        {
            if (numeroDeCadeiras == 40)
            {
                return metodos.Preco3D();
            }
            else
            {

               
                if (Convert.ToInt32(Convert.ToDateTime(data).Hour) <= 11 && Convert.ToInt32(Convert.ToDateTime(data).Hour) >= 6)
                {
                    return metodos.PrecoManha();
                }
                else if (Convert.ToDateTime(data).Hour >= 12 && Convert.ToDateTime(data).Hour <= 17)
                {
                    return metodos.PrecoTarde();
                }
                else if (Convert.ToDateTime(data).Hour >= 18 || Convert.ToDateTime(data).Hour <= 5)
                {
                    return metodos.PrecoNoite();
                }
                else
                {
                    return null;
                }
            }
        }

            public List<int> Cadeira(int idSessao)
            {
                return metodos.Cadeira(idSessao);
            }


        public void Salvar(DTOIngressoSessao dados)
        {
            dados.Cpf = dados.Cpf == "   .   .   -" ? "Não ident" : dados.Cpf;
            
            metodos.Salvar(dados);
        }


    }
}
