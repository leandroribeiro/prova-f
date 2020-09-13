using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaF.Domain.Exceptions;
using ProvaF.Domain.Services;
using ProvaF.Infrastructure.Data;
using Xunit;

namespace ProvaF.Domain.Tests.IntegrationTests
{
    public class ContaServiceTests : BaseIntegrationTest
    {
        private readonly ContaService _service;

        public ContaServiceTests() : base()
        {
            
            var repository = new ContaRepository(Context);
            _service = new ContaService(repository);
        }
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorValido_Quando_EfetuarSaque_Entao_Deve_Diminuir_Valor_da_Conta()
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
            var valorSaque = 2000;
            var saldoAnterior = _service.ObterSaldo(numeroConta);
            
            // ACT
            // ASSERT
            _service.Invoking(s => s.Sacar(numeroConta, valorSaque))
                .Should().Throw<BusinessRuleValidationException>()
                .WithMessage("Saldo insuficiente.");

        }
        
        [Fact]
        public void Dado_uma_ContaInvalida_Quando_Tentar_EfetuarSaque_Entao_Deve_Retornar_um_Erro()
        {
            // ARRANGE
            var valorSaque = 1;
            var numeroConta = 123;
            
            // ACT
            // ASSERT
            _service.Invoking(s => s.Sacar(numeroConta, valorSaque))
                .Should().Throw<BusinessRuleValidationException>()
                .WithMessage("A conta informada não existe.");
        }
        
        [Fact]
        public void Dado_uma_ContaValida_Quando_ConsultarSaldo_Entao_deve_retornar_o_saldo_atual()
        {
            // ARRANGE
            var numeroConta = 3;
            
            // ACT
            var saldo = _service.ConsultarSaldo(numeroConta);
            
            // ASSERT
            saldo.Should().Be(300);

        }
    }
}