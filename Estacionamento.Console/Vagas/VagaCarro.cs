namespace Estacionamento.Console.Vagas;

public class VagaCarro : Vaga
{
    public VagaCarro(int id)
    {
        Prefixo = "C";
        Id = $"C{id}";
        TipoVaga = TipoVaga.Carro;
    }
}