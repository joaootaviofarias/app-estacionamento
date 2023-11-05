using Estacionamento.Console.Vagas;
using Estacionamento.Console.Veiculos;

namespace Estacionamento.Console;

public class Estacionamento
{
    private readonly List<Vaga> _vagas = new();
    
    public Estacionamento(int quantidadeCarros, int quantidadeMotos, int quantidadeVans)
    {
        _vagas.AddRange(Enumerable.Range(0, quantidadeCarros)
            .Select(x => new VagaCarro(x))
            .ToList());
        
        _vagas.AddRange(Enumerable.Range(0, quantidadeMotos)
            .Select(x => new VagaMoto(x))
            .ToList());
        
        _vagas.AddRange(Enumerable.Range(0, quantidadeVans)
            .Select(x => new VagaVan(x))
            .ToList());
    }

    public IReadOnlyCollection<Vaga> Vagas => _vagas.AsReadOnly();
    public int VagasCarroDisponiveis => _vagas.Count(x => x.TipoVaga == TipoVaga.Carro && x.Veiculo is null);
    public int VagasMotoDisponiveis => _vagas.Count(x => x.TipoVaga == TipoVaga.Moto && x.Veiculo is null);
    public int VagasVanDisponiveis => _vagas.Count(x => x.TipoVaga == TipoVaga.Van && x.Veiculo is null);

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        veiculo.Estacionar(_vagas);
    }

    public void RemoverVeiculo(string placa)
    {
        var vagas = _vagas.Where(x => x.Veiculo?.Placa == placa);

        foreach (var vaga in vagas)
            vaga.RemoverVeiculo();
    }
}