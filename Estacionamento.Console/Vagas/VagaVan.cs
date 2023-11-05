namespace Estacionamento.Console.Vagas;

public class VagaVan : Vaga
{
    public VagaVan(int id)
    {
        Prefixo = "V";
        Id = $"V{id}";
        TipoVaga = TipoVaga.Van;
    }
}