using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteHabilidade.RegrasNegocios;

namespace ImpostoRendaTeste
{
    [TestClass]
    public class CalculadoraIRTeste
    {
        [TestMethod]
        public void DescontoPorDependenteTeste()
        {
            var numeroDependentes = 5;
            var salarioMinimo = 600;
            var desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            Assert.AreEqual(150m, desconto);

            numeroDependentes = 0;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            Assert.AreEqual(0m, desconto);
        }

        [TestMethod]
        public void RendaLiquidaTeste()
        {
            var rendaBruta = 1000;
            var numeroDependentes = 5;
            var salarioMinimo = 600;
            var desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            var rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            Assert.AreEqual(850m, rendaLiquida);

            numeroDependentes = 0;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            Assert.AreEqual(rendaBruta, rendaLiquida);
        }

        [TestMethod]
        public void QuantidadeSalariosMinimosTeste()
        {
            var rendaBruta = 1000;
            var numeroDependentes = 5;
            var salarioMinimo = 500;
            var desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            var rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            var quantidadeSalariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            Assert.AreEqual(1.75f, quantidadeSalariosMinimos);

            numeroDependentes = 0;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            quantidadeSalariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            Assert.AreEqual(2, quantidadeSalariosMinimos);
        }

        [TestMethod]
        public void PercentualAliquotaTeste()
        {
            var rendaBruta = 5000;
            var numeroDependentes = 5;
            var salarioMinimo = 500;
            var desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            var rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            var quantidadeSalariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            var aliquota = CalculadoraIR.PercentualAliquota(quantidadeSalariosMinimos);
            Assert.AreEqual(0.275f, aliquota);

            rendaBruta = 3000;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            quantidadeSalariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(quantidadeSalariosMinimos);
            Assert.AreEqual(0.225f, aliquota);

            rendaBruta = 2500;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            quantidadeSalariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(quantidadeSalariosMinimos);
            Assert.AreEqual(0.15f, aliquota);

            rendaBruta = 2000;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            quantidadeSalariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(quantidadeSalariosMinimos);
            Assert.AreEqual(0.075f, aliquota);

            rendaBruta = 1000;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            quantidadeSalariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(quantidadeSalariosMinimos);
            Assert.AreEqual(0f, aliquota);
        }

        [TestMethod]
        public void ImpostoRendaTest()
        {
            var rendaBruta = 5000;
            var salarioMinimo = 500;
            var numeroDependentes = 5;
            var desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            var rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            var salariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            var aliquota = CalculadoraIR.PercentualAliquota(salariosMinimos);
            var impostoRenda = CalculadoraIR.ImpostoRenda(rendaLiquida, aliquota);
            Assert.AreEqual(1340.625m, impostoRenda);

            rendaBruta = 4000;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            salariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(salariosMinimos);
            impostoRenda = CalculadoraIR.ImpostoRenda(rendaLiquida, aliquota);
            Assert.AreEqual(1065.62500m, impostoRenda);

            rendaBruta = 3000;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            salariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(salariosMinimos);
            impostoRenda = CalculadoraIR.ImpostoRenda(rendaLiquida, aliquota);
            Assert.AreEqual(646.875M, impostoRenda);

            rendaBruta = 2000;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            salariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(salariosMinimos);
            impostoRenda = CalculadoraIR.ImpostoRenda(rendaLiquida, aliquota);
            Assert.AreEqual(140.625m, impostoRenda);

            rendaBruta = 1000;
            desconto = CalculadoraIR.DescontoPorDependente(salarioMinimo, numeroDependentes);
            rendaLiquida = CalculadoraIR.RendaLiquida(rendaBruta, desconto);
            salariosMinimos = CalculadoraIR.QuantidadeSalariosMinimos(salarioMinimo, rendaLiquida);
            aliquota = CalculadoraIR.PercentualAliquota(salariosMinimos);
            impostoRenda = CalculadoraIR.ImpostoRenda(rendaLiquida, aliquota);
            Assert.AreEqual(0m, impostoRenda);
        }
    }
}
