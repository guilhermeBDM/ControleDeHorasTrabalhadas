using ControleDeHorasTrabalhadas;
using NSF.TCC.Sundown.DataAccess;
using NSF.TCC.Sundown.Model.DTOs;
using NSF.TCC.Sundown.Model.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSF.TCC.Sundown.Business
{
    public class FolhaPagamentoBusiness
    {
        public string UltimaDataRegistrado { get; set; }

        public int HoraExtra(int id)
        {
            FolhaPagamentoDataBase resultado = new FolhaPagamentoDataBase();
            string dataPonto = resultado.UltimaDataFolha(id);
            this.UltimaDataRegistrado = dataPonto == "0" ? "01/01/0001 00:00:00" : dataPonto;

            List<DTOPonto> datasHoras = resultado.ListarHoraExtra(id, dataPonto);

            double horaExtra = 0;
            int percorrer = 0;
            
            int tamanho = datasHoras.Count() - 1;

            for (int i = 0; i < tamanho; i++)
            {

                if (datasHoras[tamanho - i].Status != "FIM HORA EXTRA")
                {
                    datasHoras.RemoveAt(tamanho - i);
                }
                else
                {
                    break;
                }
            }
            foreach (var item in datasHoras)
            {
                ++percorrer;

                if (datasHoras.Count() > 1 && ((item.Status == "INÍCIO HORA EXTRA" && datasHoras[percorrer].Status == "PAUSA HORA EXTRA") || (item.Status == "RETORNO HORA EXTRA" && datasHoras[percorrer].Status == "PAUSA HORA EXTRA") || (item.Status == "RETORNO HORA EXTRA" && datasHoras[percorrer].Status == "FIM HORA EXTRA") || (item.Status == "INÍCIO HORA EXTRA" && datasHoras[percorrer].Status == "FIM HORA EXTRA")))
                {
                    DateTime data = new DateTime(int.Parse(item.Movement.Substring(6, 4)), int.Parse(item.Movement.Substring(3, 2)), int.Parse(item.Movement.Substring(0, 2)), int.Parse(item.Movement.Substring(11, 2)), int.Parse(item.Movement.Substring(14, 2)), int.Parse(item.Movement.Substring(17, 2)));

                    DateTime data1 = new DateTime(int.Parse(datasHoras[percorrer].Movement.Substring(6, 4)), int.Parse(datasHoras[percorrer].Movement.Substring(3, 2)), int.Parse(datasHoras[percorrer].Movement.Substring(0, 2)), int.Parse(datasHoras[percorrer].Movement.Substring(11, 2)), int.Parse(datasHoras[percorrer].Movement.Substring(14, 2)), int.Parse(datasHoras[percorrer].Movement.Substring(17, 2)));
                    TimeSpan diferenca = data1 - data;
                    horaExtra = horaExtra + diferenca.TotalMinutes;

                    this.UltimaDataRegistrado = datasHoras[percorrer].Movement;
                }
            }


            return Convert.ToInt32(Math.Round(horaExtra));
        }

        public void InserirResultado(DTOFolhaDePagamento dados)
        {
            FolhaPagamentoDataBase resultado = new FolhaPagamentoDataBase();
            resultado.InserirResultado(dados);
        }

        public VOConsultarFolha ConsultaFolha(int id, string data)
        {
            FolhaPagamentoDataBase dados = new FolhaPagamentoDataBase();
            return dados.ConsultaFolha(id,data);
        }

        public List<string> Data(int id)
        {
            FolhaPagamentoDataBase dados = new FolhaPagamentoDataBase();
            return dados.Data(id);
        }

        public bool UltimaFolha(int id)
        {
            FolhaPagamentoDataBase dados = new FolhaPagamentoDataBase();
         
                return dados.UltimaFolha(id) == DateTime.Now.ToString("yyyy-MM").ToString() ? false : true;
            
        }

        public decimal SalarioBruto { get; set; }
        public decimal ValorHoraExtra { get; set; }
        public decimal TempoHoraExtra { get; set; }
        public decimal SalarioCalcularImposto { get; set; }
        public decimal HoraPorValor { get; set; }
        public decimal InssProp { get; set; }

        public decimal HoraValor()
        {
            this.HoraPorValor = this.SalarioBruto / 220;
            return this.SalarioBruto / 220;

        }

        public decimal CalcularHoraExtra()
        {
            return this.HoraPorValor * ((this.ValorHoraExtra / 100) + 1) * (this.TempoHoraExtra);
        }

        public decimal Dsr()
        {
            return this.HoraPorValor * ((this.ValorHoraExtra / 100) + 1) * 4;
        }

        public decimal Fgts()
        {
            return this.SalarioCalcularImposto * Convert.ToDecimal(0.08);
        }

        public decimal Inss()
        {
            decimal inss = 0;

            if (this.SalarioCalcularImposto <= Convert.ToDecimal(1659.38))
            {
                inss = this.SalarioCalcularImposto * Convert.ToDecimal(0.08);
            }

            if (this.SalarioCalcularImposto >= Convert.ToDecimal(1659.39) && this.SalarioCalcularImposto <= Convert.ToDecimal(2765.66))
            {
                inss = this.SalarioCalcularImposto * Convert.ToDecimal(0.09);
            }

            if (this.SalarioCalcularImposto >= Convert.ToDecimal(2765.67) && this.SalarioCalcularImposto <= Convert.ToDecimal(5531.31))
            {
                inss = this.SalarioCalcularImposto * Convert.ToDecimal(0.11);
            }
            if (this.SalarioCalcularImposto > Convert.ToDecimal(5531.31))
            {
                inss = Convert.ToDecimal(608.44);
            }
            this.InssProp = inss;
            return inss;
        }

        public decimal Irrf(decimal inss)
        {
            decimal irrfMenosInss = (this.SalarioCalcularImposto - this.InssProp);
            decimal irrf = 0;

            if (irrfMenosInss >= Convert.ToDecimal(1903.39) && irrfMenosInss <= Convert.ToDecimal(2826.65))
            {
                irrf = irrfMenosInss * Convert.ToDecimal(0.075);
                irrf = irrf <= Convert.ToDecimal(142.80) ? irrf : Convert.ToDecimal(142.80);
            }

            if (irrfMenosInss >= Convert.ToDecimal(2826.65) && irrfMenosInss <= Convert.ToDecimal(3751.05))
            {
                irrf = irrfMenosInss * Convert.ToDecimal(0.15);
                irrf = irrf <= Convert.ToDecimal(354.80) ? irrf : Convert.ToDecimal(354.80);
            }
            if (irrfMenosInss >= Convert.ToDecimal(3751.06) && irrfMenosInss <= Convert.ToDecimal(4664.68))
            {
                irrf = irrfMenosInss * Convert.ToDecimal(0.225);
                irrf = irrf <= Convert.ToDecimal(636.13) ? irrf : Convert.ToDecimal(636.13);
            }
            if (irrfMenosInss > Convert.ToDecimal(4664.68))
            {
                irrf = irrfMenosInss * Convert.ToDecimal(0.275);
                irrf = irrf <= Convert.ToDecimal(869.36) ? irrf : Convert.ToDecimal(869.36);
            }

            return irrf;
        }

        public decimal Atraso(decimal atraso)
        {
            return this.HoraPorValor * (atraso / 60);
        }

        public decimal Faltas(decimal faltas)
        {
            return (this.SalarioBruto / 30) * faltas;
        }

        public decimal SalarioFamilia(decimal filhos)
        {
            return filhos * Convert.ToDecimal(31.07);
        }

        public decimal ValeTransporte(bool info)
        {
            return info == true ? this.SalarioBruto * Convert.ToDecimal(0.06) : 0;
        }


    }
}
