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
    public class AtualizarUsuario
    {
        public bool Clear { get; set; }

        public void Alterar(int id, string email, string nome, string pass, string user, string cpf, string telefone,string cep,decimal numerodacasa,decimal salariobruto,string setor, bool adm, bool vendas, bool compras, bool contabilidade, bool fin, bool rh, decimal va, decimal vr, decimal sf, bool saude, bool transporte, bool rhcargos, bool ageral, bool mkt, bool cont, bool gerentelocal,DateTime Aniversario)
        {
            if ((email == string.Empty || nome == string.Empty || pass == string.Empty || user == string.Empty || cpf == string.Empty || cpf == string.Empty || cep == string.Empty || numerodacasa == 0 || salariobruto < 0))
            {

                MessageBox.Show("FALHA,PREENCHA OS CAMPOS!", "TOPMOVIE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear = false;
            }
            else
            {

              
                CrudDataBase AttDb = new CrudDataBase();

                // Salvar o usuário
                DTOUser usuarioDTO = new DTOUser();

                usuarioDTO.Nome = nome;
                usuarioDTO.User = user;
                usuarioDTO.Password = pass;
                usuarioDTO.Email = email;
                usuarioDTO.Cpf = cpf;
                usuarioDTO.PostalCode = cep;
                usuarioDTO.HouseNumber = numerodacasa;
                usuarioDTO.Telefone = telefone;
                usuarioDTO.Id = id;
                usuarioDTO.Birth = Aniversario;

                AttDb.UpdateAtendente(usuarioDTO);

                // Salvar permissão

                DTOPermission permissaoDTO = new DTOPermission();


                permissaoDTO.Administrator = adm;
                permissaoDTO.Rh = rh;
                permissaoDTO.Fin = fin;
                permissaoDTO.Cont = contabilidade;
                permissaoDTO.Vend = vendas;
                permissaoDTO.Comp = compras;
                permissaoDTO.IdUser = id;

                AttDb.UpdatePerms(permissaoDTO);



                //Cargos
                DTOCargos cargosDTO = new DTOCargos();
                cargosDTO.AGeral = ageral;
                cargosDTO.Contabilidade = cont;
                cargosDTO.GerenteLocal = gerentelocal;
                cargosDTO.Marketing = mkt;
                cargosDTO.Rh = rhcargos;
                cargosDTO.IdUser = id;

                AttDb.UpdateCargos(cargosDTO);


                //Salvar o setor
                DTOSector setorDTO = new DTOSector();

                setorDTO.Setor = setor;
                setorDTO.IdUsuario = id;

                AttDb.UpdateSetor(setorDTO);


                ////Salvar beneficios
                DTOBenefit beneficiosDTO = new DTOBenefit();

                beneficiosDTO.CommuterBenefits = transporte;
                beneficiosDTO.FamilySalary = sf;
                beneficiosDTO.HealthInsurance = saude;
                beneficiosDTO.MealTicket = vr;
                beneficiosDTO.MealVoucher = va;
                beneficiosDTO.IdUsuario = id;

                AttDb.UpdateBnef(beneficiosDTO);

                //Salvar o salário bruto
                DTOSalarioBruto salariobrutoDTO = new DTOSalarioBruto();
                salariobrutoDTO.SalarioBruto = salariobruto;
                salariobrutoDTO.IdUser = id;

                AttDb.InserirSalarioBruto(salariobrutoDTO);


                MessageBox.Show("NOVA ATUALIZAÇÃO REALIZADA!", "TOPMOVIE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear = true;





                
            }
        }

}   }
