using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model;
using NSF.TCC.Sundown.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSF.TCC.Sundown.Business
{
    public class NovoAtendente
    {
        public bool Clear { get; set; }

        public void Save(string email, string nome, string pass, string user, string cpf, DateTime nascimento, string cep, string telefone, decimal numerodacasa, decimal salariobruto, bool adm, bool vendas, bool compras, bool contabilidade, bool fin, bool rh, string setor, decimal va, decimal vr, decimal sf, bool saude, bool transporte, bool rhcargos, bool ageral, bool mkt, bool cont, bool gerentelocal)
        {
            if (email == string.Empty || nome == string.Empty || pass == string.Empty || user == string.Empty || cpf == string.Empty || cpf == string.Empty || cep == string.Empty || numerodacasa == 0 || salariobruto < 0)
            {

                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear = false;
            }
            else if (rhcargos == false && ageral == true && mkt == true && cont == true && gerentelocal == true)
            {
                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear = false;


            }

            else
            {


                CrudDataBase AtendenteDatabass = new CrudDataBase();
                int CpfQuantidade = AtendenteDatabass.ValidacaoCpf(cpf);
                int EmailQuantidade = AtendenteDatabass.ValidacaoEmail(email);

                if (EmailQuantidade > 0)
                {
                    MessageBox.Show("FALHA,ESSE EMAIL É UTILIZADO POR UM FUNCIONÁRIO ATIVO!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (CpfQuantidade > 0)
                {
                    MessageBox.Show("FALHA,ESSE CPF É UTILIZADO POR UM FUNCIONÁRIO ATIVO!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    // Salvar o usuário
                    DTOUser usuarioDTO = new DTOUser();

                    usuarioDTO.Nome = nome;
                    usuarioDTO.User = user;
                    usuarioDTO.Password = pass;
                    usuarioDTO.Email = email;
                    usuarioDTO.Cpf = cpf;
                    usuarioDTO.Birth = nascimento;
                    usuarioDTO.PostalCode = cep;
                    usuarioDTO.HouseNumber = numerodacasa;
                    usuarioDTO.Telefone = telefone;


                    int idUsuario = AtendenteDatabass.SaveUser(usuarioDTO);

                    // Salvar permissão
                    DTOPermission permissaoDTO = new DTOPermission();


                    permissaoDTO.Administrator = adm;
                    permissaoDTO.Rh = rh;
                    permissaoDTO.Fin = fin;
                    permissaoDTO.Cont = contabilidade;
                    permissaoDTO.Vend = vendas;
                    permissaoDTO.Comp = compras;
                    permissaoDTO.IdUser = idUsuario;

                    AtendenteDatabass.SavePermission(permissaoDTO);

                    //Salvar cargos

                    DTOCargos cargosDTO = new DTOCargos();

                    cargosDTO.AGeral = ageral;
                    cargosDTO.Contabilidade = cont;
                    cargosDTO.Marketing = mkt;
                    cargosDTO.GerenteLocal = gerentelocal;
                    cargosDTO.Rh = rhcargos;
                    cargosDTO.IdUser = idUsuario;

                    AtendenteDatabass.SaveCargo(cargosDTO);




                    //Salvar o setor
                    DTOSector setorDTO = new DTOSector();

                    setorDTO.Setor = setor;
                    setorDTO.IdUsuario = idUsuario;

                    AtendenteDatabass.SaveSetor(setorDTO);


                    //Salvar beneficios
                    DTOBenefit beneficiosDTO = new DTOBenefit();

                    beneficiosDTO.CommuterBenefits = transporte;
                    beneficiosDTO.FamilySalary = sf;
                    beneficiosDTO.HealthInsurance = saude;
                    beneficiosDTO.MealTicket = vr;
                    beneficiosDTO.MealVoucher = va;
                    beneficiosDTO.IdUsuario = idUsuario;

                    AtendenteDatabass.SaveBenef(beneficiosDTO);

                    //Salvar salário bruto
                    DTOSalarioBruto salariobrutoDTO = new DTOSalarioBruto();

                    salariobrutoDTO.IdUser = idUsuario;
                    salariobrutoDTO.SalarioBruto = salariobruto;

                    AtendenteDatabass.SaveSalarioBruto(salariobrutoDTO);

                    MessageBox.Show("NOVA ADMISSÃO REALIZADA!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear = true;
                }





            }



        }
    }
}
