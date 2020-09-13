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
        private ContaService _conta;

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
            _conta = new ContaService(repository);
        }
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorValida_Quando_EfetuarSaque_Entao_Deve_Diminuir_Valor_da_Conta()
        {
            // ARRANGE
            var numeroConta = 123;
            var valorSaque = 100;
            var saldoAnterior = _conta.ObterSaldo(numeroConta);
            
            // ACT
            var saldo = _conta.Sacar(numeroConta, valorSaque);
            
            // ASSERT
            Assert.True(saldo < saldoAnterior, "saldo < saldoAnterior");

        }
    }
}