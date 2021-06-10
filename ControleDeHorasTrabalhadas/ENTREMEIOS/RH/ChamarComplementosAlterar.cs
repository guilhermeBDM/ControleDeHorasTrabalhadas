using NSF.TCC.Sundown.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSF.TCC.Sundown.Business
{
    public class ChamarComplementosAlterar
    {
        //User
        public string Nome;
        public string Cpf;
        public string Cep;
        public string User;
        public string Email;
        public string Password;
        public decimal NumeroCasa;
        public string Telefone;
        public DateTime Nascimento;
        //Setor
        public string Setor;
        //Funções
        public bool Adm;
        public bool Rh;
        public bool Fin;
        public bool Cont;
        public bool Comp;
        public bool Vend;
        //Beneficios
        public bool    Transporte;
        public bool    Saude;
        public decimal SalarioFamilia;
        public decimal ValeRefeicao;
        public decimal ValeAlimentacao;
        //Salario Bruto
        public int IdSalarioBruto;
        public decimal SalarioBruto;
        //Cargos
        public bool RhC;
        public bool Marketing;
        public bool Contabilidade;
        public bool GerenteLocal;
        public bool AGeral;




        //Pegar dados para listar
        public void BuscaUser(int id)
        {

            ChamarDados cd = new ChamarDados();

            
            cd.ListAllDadosUser(id);
            cd.ListSetor(id);
            cd.ListPerms(id);
            cd.ListBenef(id);
            cd.ListBrutos(id);
            cd.ListCargos(id);
            //Permissões
            Adm = cd.Adm;
            Rh = cd.Rh;
            Fin = cd.Fin;
            Cont = cd.Cont;
            Comp = cd.Comp;
            Vend = cd.Vend;
            //Cargos
            RhC = cd.RhC;
            Marketing = cd.Marketing;
            Contabilidade = cd.Marketing;
            GerenteLocal = cd.GerenteLocal;
            AGeral = cd.AGeral;

            //Dados usuários
            Nome = cd.Nome;
            Cpf = cd.Cpf;
            Cep = cd.Cep;                    
            User = cd.User;
            Email = cd.Email;
            Password = cd.Password;
            NumeroCasa = cd.NumeroCasa;
            Telefone = cd.Telefone;
            Nascimento = cd.Nascimento;
            //Setor
            Setor = cd.Setor;
            //Beneficios
            Transporte = cd.Transporte;
            Saude = cd.Saude;
            SalarioFamilia = cd.SalarioFamilia;
            ValeRefeicao = cd.ValeRefeicao;
            ValeAlimentacao = cd.ValeAlimentacao;
            //Salario Bruto
            IdSalarioBruto = cd.IdSalarioBruto;
            SalarioBruto = cd.SalarioBruto;
            
        }


    }
}
