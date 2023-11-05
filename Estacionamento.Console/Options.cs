using CommandLine;

namespace Estacionamento.Console;

public class Options
{
    [Option("vagas-carro")]
    public int QuantidadeVagaCarro { get; set; }
    [Option("vagas-moto")]
    public int QuantidadeVagaMoto { get; set; }
    [Option("vagas-van")]
    public int QuantidadeVagaVan { get; set; }
}