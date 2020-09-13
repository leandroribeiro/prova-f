using FluentAssertions;
using ProvaF.Domain.Exceptions;
using ProvaF.Domain.Services;
using ProvaF.Infrastructure.Data;
using Xunit;

namespace ProvaF.Domain.Tests.IntegrationTests
{
    public class ContaServiceTests : BaseIntegrationTest
    {
        private readonly IContaService _service;

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
        public void Dado_uma_ContaValida_e_ValorMaior_que_Saldo_Quando_EfetuarSaque_Entao_deve_Retornar_Erro_de_Negocio()
        {
            // ARRANGE
            var numeroConta = 1;
            var valorSaque = 2000;
            var saldoAnterior = _service.ObterSaldo(numeroConta);
            
            // ACT
            // ASSERT
            _service.Invoking(s => s.Sacar(numeroConta, valorSaque))
                .Should().Throw<ValorInvalidoValidationException>()
                .WithMessage("Saldo insuficiente.");

        }
        
        [Fact]
        public void Dado_uma_ContaInvalida_Quando_EfetuarSaque_Entao_Deve_Retornar_um_Erro()
        {
            // ARRANGE
            var valorSaque = 1;
            var numeroConta = 123;
            
            // ACT
            // ASSERT
            _service.Invoking(s => s.Sacar(numeroConta, valorSaque))
                .Should().Throw<ContaInvalidaValidationException>()
                .WithMessage("A conta informada não existe.");
        }
        
        [Fact]
        public void Dado_uma_ContaValida_Quando_ConsultarSaldo_Entao_deve_retornar_o_saldo_atual()
        {
            // ARRANGE
            var numeroConta = 3;
            
            // ACT
            var saldo = _service.ObterSaldo(numeroConta);
            
            // ASSERT
            saldo.Should().Be(300);

        }
        
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorValido_Quando_EfetuarDeposito_Entao_deve_Aumentar_Saldo()
        {
            // ARRANGE
            var valorDeposito = 200;
            var numeroConta = 2;
            var saldoAnterior = _service.ObterSaldo(2);
            
            // ACT
            var saldo = _service.Depositar(numeroConta, valorDeposito);
            
            // ASSERT
            saldo.Should().BeGreaterThan(saldoAnterior);
        }
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorInvalido_Quando_EfetuarDeposito_Entao_deve_retornar_um_Erro()
        {
            // ARRANGE
            var valorDeposito = -333;
            var numeroConta = 1;
            var saldoAnterior = _service.ObterSaldo(2);
            
            // ACT
            // ASSERT
            _service.Invoking(s => s.Depositar(numeroConta, valorDeposito))
                .Should().Throw<ValorInvalidoValidationException>()
                .WithMessage("Valor inválido.");
        }
    }
}