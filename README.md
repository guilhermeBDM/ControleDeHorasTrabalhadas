# ControleDeHorasTrabalhadas


Tela de Login:
    Campos de texto para preenchimento de email e senha e um botão para enviar e validar esses valores de acordo com os colaboradores cadastrados.

Tela de Ponto/Menu:
    Caixa de seleção para que o  usuário escolha o status que quer definir o ponto (entrada, pausa, retorno de pausa, saída) e um botão para registro do ponto(que leva para a tela de confirmação).

Tela de confirmação de ponto:
    É disposto ao usuário os dados que serão salvos nesse registro. Os dados são: Data, horário, geolocalização e o tipo de movimento (status escolhido na tela de ponto)

Tela de Consulta do Histórico Pessoal:
    Tabela para visualização do histórico pessoal geral com todos os pontos filtrados por uma data. Nesta tela, selecionando alguma marcação de ponto qualquer, o usuário pode abrir um chamado para alterar as informações do ponto selecionado, clicando em um botão localizado na parte inferior da interface.

Tela de Abertura de Chamado para Alterar Ponto:
    Tela com campo de texto para informar um novo horário para o movimento, combobox para selecionar o movimento/tipo do ponto e outro campo de texto para o motivo da alteração do ponto. Há dois botões na interface, um para cancelar o desejo de alteração e um outro para confirmar esta operação.

Tela de Chamados Abertos para Alteração de Ponto(RH):
    Tabela para visualizar/consultar os chamados de alteração de ponto ainda abertos. Clicando em um chamado, o usuário pode negar ou permitir a alteração, em qualquer um dos casos a tela para inserir a justificativa da decisão é aberta.
Tela de justificativa para decisão em alteração de ponto(RH):
    A interface dispõe de uma  caixa de texto que permite o usuário escrever uma justificativa para a decisão de negar ou permitir uma alteração e dois botões, sendo eles: Enviar e Cancelar, o primeiro continua com a decisão de tomar uma decisão e o segundo retorna para a tela de consulta de chamados pois o usuário desistiu da decisão.

Tela de Consultas (RH):
    Colaboradores de RH podem visualizar as marcações filtradas por usuários e período (diferença entre datas). A tabela irá mostrar todos os dias que o colaborador marcou presença e o total de horas que ele fez na data.  Com um doubleclick em um dia qualquer é possível ver todas marcações desse dia específico. Há um botão para gerar um relatório PDF desse período  filtrado. A regra do relatório é exibir os dados da tabela inicial (os dias dentro do período escolhido e a quantidade de horas feitas em cada dia)
