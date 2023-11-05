using Estacionamento.Console.Vagas;

namespace Estacionamento.Console.Veiculos;

public abstract class Veiculo
{
    protected Veiculo(string placa)
    {
        Placa = placa;
    }
    
    public string Placa { get; private set; }
    public VeiculoTipo Tipo { get; protected init; }

    public abstract void Estacionar(List<Vaga> vagas);
}