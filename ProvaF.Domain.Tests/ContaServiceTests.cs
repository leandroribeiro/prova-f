using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaF.Domain.Services;
using ProvaF.Infrastructure.Data;
using Xunit;

namespace ProvaF.Domain.Tests
{
    public class ContaServiceTests
    {
        private ContaService _service;

        public ContaServiceTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkNpgsql()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ProvaFDbContext>();

            builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseInternalServiceProvider(serviceProvider);
            
            var context = new ProvaFDbContext(builder.Options);
            var repository = new ContaRepository(context);
            _service = new ContaService(repository);
        }
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorValida_Quando_EfetuarSaque_Entao_Deve_Diminuir_Valor_da_Conta()
        {
            // ARRANGE
            var numeroConta = 1;
            var valorSaque = 50;
            var saldoAnterior = _service.ObterSaldo(numeroConta);
            
            // ACT
            var saldo = _service.Sacar(numeroConta, valorSaque);
            
            // ASSERT
            saldo.Should().BeLessThan(saldoAnterior);

        }
        
        
        [Fact]
        public void Dado_uma_ContaValida_e_Valor_Maior_que_Saldo_Entao_Deve_Retornar_Erro_de_Negocio()
        {
            // ARRANGE
            var numeroConta = 1;
            var valorSaque = 200;
            var saldoAnterior = _service.ObterSaldo(numeroConta);
            
            // ACT
            var saldo = _service.Sacar(numeroConta, valorSaque);
            
            // ASSERT

        }
        
        [Fact]
        public void Dado_uma_ContaInvalida_Quando_Tentar_EfetuarSaque_Entao_Deve_Retornar_um_Erro()
        {
            // ARRANGE
            var numeroConta = 123;
            
            // ACT
            var saldoAnterior = _service.ObterSaldo(numeroConta);
            
            // ASSERT

        }
    }
}