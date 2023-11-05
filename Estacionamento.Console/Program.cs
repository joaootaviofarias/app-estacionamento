using CommandLine;
using Estacionamento.Console;
using Estacionamento.Console.Veiculos;

var options = new Parser().ParseArguments<Options>(args).Value;

var estacionamento = new Estacionamento.Console.Estacionamento(
    options.QuantidadeVagaCarro,
    options.QuantidadeVagaMoto,
    options.QuantidadeVagaVan
);

var commandosMap = new Dictionary<string, Action<string>>
{
    { "adicionar-carro", (p) => estacionamento.AdicionarVeiculo(new Carro(p)) },
    { "adicionar-moto", (p) => estacionamento.AdicionarVeiculo(new Moto(p)) },
    { "adicionar-van", (p) => estacionamento.AdicionarVeiculo(new Van(p)) },
    { "remover", (p) => estacionamento.RemoverVeiculo(p) }
};

while (true)
{
    Console.WriteLine("Estacionamento");
    Console.WriteLine("Vagas disponiveis");
    Console.WriteLine($"Carro: {estacionamento.VagasCarroDisponiveis} Moto: {estacionamento.VagasMotoDisponiveis} Van: {estacionamento.VagasVanDisponiveis}");

    var input = Console.ReadLine();
    var comandoModel = ParseInput(input);

    ExecutarComando(commandosMap, comandoModel);
    
    Console.Clear();
}

ComandoModel? ParseInput(string? input)
{
    var inputParse = input?.Split(" ").ToList();
    var comando = inputParse?.First();
    var placa = inputParse?.Last();

    if (comando is null || placa is null)
        return null;
    
    return new ComandoModel()
    {
        Comando = comando,
        Placa = placa
    };
}

void ExecutarComando(Dictionary<string, Action<string>> comandoMap, ComandoModel? comandoModel)
{
    try
    {
        if (comandoModel is null)
            return;
        
        var comandoExecutar = comandoMap.GetValueOrDefault(comandoModel.Comando);

        if (comandoExecutar is null)
            return;
        
        comandoExecutar.Invoke(comandoModel.Placa);
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
        
        Thread.Sleep(1000);
    }
}