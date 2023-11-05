using Estacionamento.Console.Vagas;

namespace Estacionamento.Console.Veiculos;

public class Moto : Veiculo
{
    public Moto(string placa) : base(placa)
    {
        Tipo = VeiculoTipo.Moto;
    }

    public override void Estacionar(List<Vaga> vagas)
    {
        var vagasPermitidas = new List<TipoVaga> { TipoVaga.Moto, TipoVaga.Carro, TipoVaga.Van };
        var vaga = vagas
            .Where(x => vagasPermitidas.Contains(x.TipoVaga))
            .OrderBy(x => vagasPermitidas.IndexOf(x.TipoVaga))
            .FirstOrDefault(x => x.Veiculo is null);
            
        if (vaga is null)
            throw new InvalidOperationException("Sem vagas disponíveis");
        
        vaga.AdicionarVeiculo(this);
    }
}