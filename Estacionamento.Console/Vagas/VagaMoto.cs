namespace Estacionamento.Console.Vagas;

public class VagaMoto : Vaga
{
    public VagaMoto(int id)
    {
        Prefixo = "M";
        Id = $"M{id}";
        TipoVaga = TipoVaga.Moto;
    }
}