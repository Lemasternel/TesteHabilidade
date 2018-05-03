using Dominio.Entidades;

namespace TesteHabilidade.RegrasNegocios
{
    public class CalculadoraIR
    {
        public static decimal DescontoPorDependente(decimal salarioMinimo, int numeroDependentes)
        {
            var salarioMinimoDescontado = salarioMinimo * 0.05m;
            var salarioMinimoDescontoPorDependente = salarioMinimoDescontado * numeroDependentes;
            
            return salarioMinimoDescontoPorDependente;
        }

        public static decimal RendaLiquida(decimal rendaBruta, decimal descontoPorDependente)
        {
            return rendaBruta - descontoPorDependente;
        }

        public static float QuantidadeSalariosMinimos(decimal salarioMinimo, decimal rendaLiquida)
        {
            var quantidadeSalariosMinimos = rendaLiquida / salarioMinimo;

            return  (float)quantidadeSalariosMinimos;
        }

        public static float PercentualAliquota(float quantidadeSalariosMinimos)
        {
            if (quantidadeSalariosMinimos > 7)
            {
                return 0.275f;
            }
            else if (quantidadeSalariosMinimos > 5 && quantidadeSalariosMinimos <= 7)
            {
                return 0.225f;
            }
            else if (quantidadeSalariosMinimos > 4 && quantidadeSalariosMinimos <= 5)
            {
                return 0.15f;
            }
            else if (quantidadeSalariosMinimos > 2 && quantidadeSalariosMinimos <= 4)
            {
                return 0.075f;
            }
            else
            {
                return 0f;
            }
        }

        public static decimal ImpostoRenda(decimal salarioLiquido, float percentualAliquota)
        {
            var descontoAliquota = salarioLiquido * (decimal)percentualAliquota;
            return descontoAliquota;
        }

        public static decimal ImpostoRenda(decimal salarioMinimo, Contribuinte contribuinte)
        {
            var descontoPorDependente = DescontoPorDependente(salarioMinimo, contribuinte.ContribuinteImpostoRenda.NumeroDependentes);
            var rendaLiquida = RendaLiquida(contribuinte.ContribuinteImpostoRenda.RendaBruta, descontoPorDependente);
            var quantidadeSalariosMinimos = QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            var percentualAliquota = PercentualAliquota(quantidadeSalariosMinimos);
            var impostoRenda = ImpostoRenda(rendaLiquida, percentualAliquota);
            return impostoRenda;
        }
    }
}
