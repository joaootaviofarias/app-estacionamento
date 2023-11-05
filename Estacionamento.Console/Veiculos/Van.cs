using Estacionamento.Console.Vagas;

namespace Estacionamento.Console.Veiculos;

public class Van : Veiculo
{
    public Van(string placa) : base(placa)
    {
        Tipo = VeiculoTipo.Van;
    }

    public override void Estacionar(List<Vaga> vagas)
    {
        var vagaVan = vagas.FirstOrDefault(x => x.TipoVaga == TipoVaga.Van && x.Veiculo is null);

        if (vagaVan != null)
        {
            vagaVan.AdicionarVeiculo(this);
        }
        else
        {
            var vagasCarro = vagas
                .Where(x => x.TipoVaga == TipoVaga.Carro && x.Veiculo == null)
                .Take(3);
                
            if (vagasCarro is null || vagasCarro.Count() < 3)
                throw new InvalidOperationException("Sem vagas disponíveis");

            foreach (var vagaCarro in vagasCarro)
            {
                vagaCarro.AdicionarVeiculo(this);
            }
        }
    }
}