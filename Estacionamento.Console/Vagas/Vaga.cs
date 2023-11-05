using Estacionamento.Console.Veiculos;

namespace Estacionamento.Console.Vagas;

public abstract class Vaga
{
    public string Prefixo { get; protected set; }
    public string Id { get; protected set; }
    public TipoVaga TipoVaga { get; set; }
    public Veiculo? Veiculo { get; private set; }

    public void AdicionarVeiculo(Veiculo veiculo) => Veiculo = veiculo;
    public void RemoverVeiculo() => Veiculo = null;
}

public enum TipoVaga
{
    Moto,
    Carro,
    Van
}