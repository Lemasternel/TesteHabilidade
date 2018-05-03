using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.Contribuinte;
using System;

namespace ImpostoRendaTeste.Contribuinte
{
    [TestClass]
    public class ContribuinteBLLTeste
    {
        [TestMethod]
        public void ValidarCPFTeste()
        {
            try
            {
                var cpf = "058";
                ContribuinteBLL.ValidarCPF(cpf);
                Assert.Fail();
            }
            catch(ArgumentException) { }

            try
            {
                var cpf = "05887451474";
                ContribuinteBLL.ValidarCPF(cpf);
                Assert.Fail();
            }
            catch (ArgumentException) { }

            try
            {
                var cpf = "058.874.51474";
                ContribuinteBLL.ValidarCPF(cpf);
                Assert.Fail();
            }
            catch (ArgumentException) { }

            try
            {
                var cpf = "058.874.514-f4";
                ContribuinteBLL.ValidarCPF(cpf);
                Assert.Fail();
            }
            catch (ArgumentException) { }

            try
            {
                var cpf = "1058.45.697-25";
                ContribuinteBLL.ValidarCPF(cpf);
                Assert.Fail();
            }
            catch (ArgumentException) { }

            try
            {
                var cpf = "058.245.697-25";
                ContribuinteBLL.ValidarCPF(cpf);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
