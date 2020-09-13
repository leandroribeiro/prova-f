using FluentAssertions;
using ProvaF.Domain.Entities;
using ProvaF.Domain.Exceptions;
using Xunit;

namespace ProvaF.Domain.Tests.UnitTests
{
    public class ContaTests
    {
        [Fact]
        public void Dado_uma_ContaValida_e_ValorValido_Quando_EfetuarSaque_Entao_deve_Retornar_um_Erro()
        {
            // ARRANGE
            var numeroDaConta = 123;
            var model = new Conta(numeroDaConta);
            var valorDoSaque = 100;
            
            // ACT
            // ASSERT
            model.Invoking(s => s.Sacar(valorDoSaque))
                .Should().Throw<ValorInvalidoValidationException>()
                .WithMessage("Saldo insuficiente.");
            
        }
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorInvalido_Quando_EfetuarSaque_Entao_deve_Retornar_um_Erro()
        {
            // ARRANGE
            var numeroDaConta = 123;
            var model = new Conta(numeroDaConta);
            var valorDoSaque = -333;
            
            // ACT
            // ASSERT
            model.Invoking(s => s.Sacar(valorDoSaque))
                .Should().Throw<ValorInvalidoValidationException>()
                .WithMessage("Valor inválido.");
            
        }
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorValido_Quando_Efetuar_um_Deposito_Entao_deve_Aumentar_Valor_da_Conta()
        {
            // ARRANGE
            var numeroDaConta = 123;
            var model = new Conta(numeroDaConta);
            var valorDoDeposito = 100;
            
            // ACT
            model.Depositar(valorDoDeposito);

            // ASSERT
            model.Saldo.Should().Be(valorDoDeposito);

        }
        
        [Fact]
        public void Dado_uma_ContaValida_e_ValorInvalido_Quando_Efetuar_um_Deposito_Entao_deve_Retornar_um_Erro()
        {
            // ARRANGE
            var numeroDaConta = 123;
            var model = new Conta(numeroDaConta);
            var valorDoDeposito = -333;
            
            // ACT
            // ASSERT
            model.Invoking(s => s.Depositar(valorDoDeposito))
                .Should().Throw<ValorInvalidoValidationException>()
                .WithMessage("Valor inválido.");

        }
    }
}