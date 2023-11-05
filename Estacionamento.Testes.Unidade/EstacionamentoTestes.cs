using Estacionamento.Console;
using Estacionamento.Console.Vagas;
using Estacionamento.Console.Veiculos;
using FluentAssertions;
using NUnit.Framework;

namespace Estacionamento.Testes.Unidade;

public class EstacionamentoTestes
{
    [Test]
    public void AdicionarVeiculo_DeveAdicionarMotoEmVagaMoto_QuandoHouverVaga()
    {
        var estacionamento = new Console.Estacionamento(1, 1, 1);
        var moto = new Moto("placa");
        
        estacionamento.AdicionarVeiculo(moto);

        var vagaOcupada = estacionamento.Vagas.FirstOrDefault(x => x.TipoVaga == TipoVaga.Moto && x.Veiculo != null);
        vagaOcupada.Veiculo.Should().BeEquivalentTo(moto);
    }

    [Test]
    public void AdicionarVeiculo_DeveAdicionarMotoEmVagaCarro_QuandoNaoHouverVagaMoto()
    {
        var estacionamento = new Console.Estacionamento(1, 1, 1);
        var vagasOcupar = estacionamento.Vagas.Where(x => x.TipoVaga != TipoVaga.Moto);
        
        foreach (var vagaOcupar in vagasOcupar)
            vagaOcupar.AdicionarVeiculo(new Moto("placa"));
        
        var moto = new Moto("placa");
        
        estacionamento.AdicionarVeiculo(moto);

        var vagaOcupada = estacionamento.Vagas.FirstOrDefault(x => x.TipoVaga == TipoVaga.Carro && x.Veiculo != null);
        vagaOcupada.Veiculo.Should().BeEquivalentTo(moto);
    }

    [Test]
    public void AdicionarVeiculo_DeveAdicionarMotoEmVagaVan_QuandoNaoHouverVagaCarroEMoto()
    {
        var estacionamento = new Console.Estacionamento(1, 1, 1);
        var vagasOcupar = estacionamento.Vagas.Where(x => x.TipoVaga != TipoVaga.Van);
        
        foreach (var vagaOcupar in vagasOcupar)
            vagaOcupar.AdicionarVeiculo(new Moto("placa"));
        
        var moto = new Moto("placa");
        
        estacionamento.AdicionarVeiculo(moto);

        var vagaOcupada = estacionamento.Vagas.FirstOrDefault(x => x.TipoVaga == TipoVaga.Van && x.Veiculo != null);
        vagaOcupada.Veiculo.Should().BeEquivalentTo(moto);
    }

    [Test]
    public void AdicionarVeiculo_DeveAdicionarCarroEmVagaCarro_QuandoHouverVaga()
    {
        var estacionamento = new Console.Estacionamento(1, 1, 1);
        var carro = new Carro("placa");
        
        estacionamento.AdicionarVeiculo(carro);

        var vagaOcupada = estacionamento.Vagas.FirstOrDefault(x => x.TipoVaga == TipoVaga.Carro && x.Veiculo != null);
        vagaOcupada.Veiculo.Should().BeEquivalentTo(carro);
    }

    [Test]
    public void AdicionarVeiculo_DeveAdicionarCarroEmVagaVan_QuandoNaoHouverVagaCarro()
    {
        var estacionamento = new Console.Estacionamento(1, 1, 1);
        var vagasOcupar = estacionamento.Vagas.Where(x => x.TipoVaga != TipoVaga.Van);
        
        foreach (var vagaOcupar in vagasOcupar)
            vagaOcupar.AdicionarVeiculo(new Carro("placa"));
        
        var carro = new Carro("placa");
        
        estacionamento.AdicionarVeiculo(carro);

        var vagaOcupada = estacionamento.Vagas.FirstOrDefault(x => x.TipoVaga == TipoVaga.Van && x.Veiculo != null);
        vagaOcupada.Veiculo.Should().BeEquivalentTo(carro);
    }

    [Test]
    public void AdicionarVeiculo_DeveAdicionarVanEmVagaVan_QuandoNaoHouverVaga()
    {
        var estacionamento = new Console.Estacionamento(1, 1, 1);
        var van = new Van("placa");
        
        estacionamento.AdicionarVeiculo(van);

        var vagaOcupada = estacionamento.Vagas.FirstOrDefault(x => x.TipoVaga == TipoVaga.Van && x.Veiculo != null);
        vagaOcupada.Veiculo.Should().BeEquivalentTo(van);
    }

    [Test]
    public void AdicionarVeiculo_DeveAdicionarVanEmTresVagaCarro_QuandoNaoHouverVagaVan()
    {
        var estacionamento = new Console.Estacionamento(4, 1, 1);
        var vagasOcupar = estacionamento.Vagas.Where(x => x.TipoVaga != TipoVaga.Carro);
        
        foreach (var vagaOcupar in vagasOcupar)
            vagaOcupar.AdicionarVeiculo(new Van("placa"));
        
        var van = new Van("placa");
        
        estacionamento.AdicionarVeiculo(van);

        var vagasOcupadas = estacionamento.Vagas.Where(x => x.TipoVaga == TipoVaga.Carro && x.Veiculo != null);
        vagasOcupadas.Count().Should().Be(3);
    }
    
}