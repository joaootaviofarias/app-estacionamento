using Estacionamento.Console.Vagas;

namespace Estacionamento.Console.Veiculos;

public class Carro : Veiculo
{
    public Carro(string placa) : base(placa)
    {
        Tipo = VeiculoTipo.Carro;
    }

    public override void Estacionar(List<Vaga> vagas)
    {
        var vagasPermitidas = new List<TipoVaga> { TipoVaga.Carro, TipoVaga.Van };
        var vaga = vagas
            .Where(x => vagasPermitidas.Contains(x.TipoVaga))
            .OrderBy(x => vagasPermitidas.IndexOf(x.TipoVaga))
            .FirstOrDefault(x => x.Veiculo is null);
            
        if (vaga is null)
            throw new InvalidOperationException("Sem vagas disponíveis");
        
        vaga.AdicionarVeiculo(this);
    }
}