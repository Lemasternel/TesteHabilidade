namespace Dominio.Entidades
{
    public class Contribuinte
    {
        public Contribuinte()
        {
            ContribuinteImpostoRenda = new ContribuinteImpostoRenda();
        }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public ContribuinteImpostoRenda ContribuinteImpostoRenda { get; set; }
    }
}
