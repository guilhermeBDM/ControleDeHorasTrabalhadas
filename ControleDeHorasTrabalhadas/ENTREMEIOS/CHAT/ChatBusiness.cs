using NSF.TCC.Sundown.DataAccess.QUERYS.CHAT;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.DTOs.CHAT;
using NSF.TCC.Sundown.Model.MAPEAMENTOS.VIEWS.CHAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class ChatBusiness
    {
        public List<ViewChat> SalaChat(int id)
        {
            ChatDataBase chat = new ChatDataBase();

            List<ViewChat> dados = new List<ViewChat>();
            dados = chat.SalaChat(id);

            int a = 0;

            foreach (var item in dados)
            {

                if (dados[a].IdChat > 0 && dados[a].Visualizou == false)
                    dados[a].Nome = "► " + dados[a].Nome;

                if (dados[a].IdChat > 0 && dados[a].Visualizou == true)
                    dados[a].Nome = "▬ " + dados[a].Nome;

                if (dados[a].IdChat == 0)
                    dados[a].Nome = "▬ " + dados[a].Nome;


                a++;
            }


            return dados;
        }

        public List<DTOChat> Listar(int idDesti, int idRemt)
        {
            ChatDataBase chat = new ChatDataBase();
            return chat.Listar(idDesti, idRemt);
        }

        public List<DTOChat> Enviado(int idDesti, int idRemt)
        {
            ChatDataBase chat = new ChatDataBase();
            return chat.Enviado(idDesti, idRemt);
        }

        public void Mensagem(DTOChat dados)
        {
            ChatDataBase chat = new ChatDataBase();
            chat.Mensagem(dados);
        }
    }
}
