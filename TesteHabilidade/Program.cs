using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Negocio.Contribuinte;
using TesteHabilidade.RegrasNegocios;

namespace TesteHabilidade
{
    class Program
    {
        static void Main(string[] args)
        {
            var contribuintes = new List<Contribuinte>();

            Console.Write("CPF: ");
            var cpf = LerCPF();
            while (cpf != "0")
            {
                var contribuinte = new Contribuinte();
                contribuinte.CPF = cpf;

                Console.Write("Nome: ");
                contribuinte.Nome = Console.ReadLine();

                Console.Write("Número de dependentes: ");
                contribuinte.ContribuinteImpostoRenda.NumeroDependentes = LerInteiro();

                Console.Write("Renda bruta mensal: ");
                contribuinte.ContribuinteImpostoRenda.RendaBruta = LerDecimal();

                contribuintes.Add(contribuinte);

                Console.Write("\nCPF: ");
                cpf = LerCPF();
            }

            if (!contribuintes.Any())
            {
                return;
            }

            Console.Write("\nValor do salário mínimo: ");
            var salarioMinimo = LerDecimal();

            foreach (var contribuinte in contribuintes)
            {
                decimal impostoRenda = CalculadoraIR.ImpostoRenda(salarioMinimo, contribuinte);
                contribuinte.ContribuinteImpostoRenda.ImpostoRenda = impostoRenda;
            }

            contribuintes = contribuintes.OrderBy(x => x.ContribuinteImpostoRenda.ImpostoRenda)
                            .ThenBy(x => x.Nome).ToList();

            Console.WriteLine();
            foreach (var item in contribuintes)
            {
                var resultados = string.Format("Contribuinte {0}, Imposto de Renda R$ {1}"
                    , item.Nome, item.ContribuinteImpostoRenda.ImpostoRenda.ToString("0.00"));

                Console.WriteLine(resultados);
            }

            Console.ReadKey();
        }

        private static string LerCPF()
        {
            var valorCorreto = false;
            var resultado = Console.ReadLine();
            while (!valorCorreto && resultado != "0")
            {
                try
                {
                    ContribuinteBLL.ValidarCPF(resultado);
                    valorCorreto = true;
                }
                catch
                {
                    string mensagemErro = string.Format("{0} não é um CPF válido! Digite novamente: ", resultado);
                    Console.WriteLine(mensagemErro);
                    resultado = Console.ReadLine();
                }
            }
            return resultado;
        }

        private static int LerInteiro()
        {
            var valorCorreto = false;
            var resultado = Console.ReadLine();
            var inteiro = 0;
            while (!valorCorreto)
            {
                try
                {
                    inteiro = int.Parse(resultado);
                    valorCorreto = true;
                }
                catch {
                    string mensagemErro = string.Format("{0} não é um número! Digite novamente: ", resultado);
                    Console.Write(mensagemErro);
                    resultado = Console.ReadLine();
                }
            }
            return inteiro;
        }

        private static decimal LerDecimal()
        {
            var valorCorreto = false;
            var resultado = Console.ReadLine();
            var @decimal = 0m;
            while (!valorCorreto)
            {
                try
                {
                    @decimal = decimal.Parse(resultado);
                    valorCorreto = true;
                }
                catch
                {
                    string mensagemErro = string.Format("{0} não é um número! Digite novamente: ", resultado);
                    Console.Write(mensagemErro);
                    resultado = Console.ReadLine();
                }
            }
            return @decimal;
        }
    }
}
