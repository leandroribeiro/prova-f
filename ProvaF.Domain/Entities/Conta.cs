using System;
using ProvaF.Domain.Exceptions;

namespace ProvaF.Domain.Entities
{
    public class Conta
    {
        public decimal Saldo { get; set; }
        public int Id { get; set; }

        private Conta()
        {
            // Apenas para chamadas do Entity Não Apague ! =|
        }
        
        public Conta(int numeroDaConta)
        {
            this.Id = numeroDaConta;
            this.Saldo = 0;
        }
        
        public void Sacar(decimal valorSaque)
        {
            if(valorSaque <= 0)
                throw new BusinessRuleValidationException("Valor inválido.");
            
            if(Saldo< valorSaque)
                throw new BusinessRuleValidationException("Saldo insuficiente.");

            this.Saldo -= valorSaque;
        }

        public void Depositar(int valorDoDeposito)
        {
            if(valorDoDeposito <= 0)
                throw new BusinessRuleValidationException("Valor inválido.");

            this.Saldo += valorDoDeposito;
        }
    }
}