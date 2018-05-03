using System;
using System.Text.RegularExpressions;

namespace Negocio.Contribuinte
{
    public static class ContribuinteBLL
    {
        public static void ValidarCPF(string CPF)
        {
            Regex cpfTeste = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
            var cpfValido = cpfTeste.IsMatch(CPF);

            if (!cpfValido)
            {
                throw new ArgumentException("O CPF não é válido!");
            }
        }
    }
}
