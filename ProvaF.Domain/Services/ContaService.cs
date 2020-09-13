using System;
using System.Threading.Tasks;
using ProvaF.Domain.Entities;
using ProvaF.Domain.Exceptions;
using ProvaF.Domain.Repositories;

namespace ProvaF.Domain.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;

        public ContaService(IContaRepository repository)
        {
            _repository = repository;
        }

        private Conta ObterConta(int numeroConta)
        {
            var conta = _repository.Obter(numeroConta);

            if (conta == null)
                throw new ContaInvalidaValidationException($"A conta informada não existe.");

            return conta;
        }
        
        public decimal ObterSaldo(int numeroConta)
        {
            var conta = ObterConta(numeroConta);

            return conta.Saldo;
        }

        public decimal Sacar(int numeroConta, decimal valorSaque)
        {
            var conta = ObterConta(numeroConta);

            conta.Sacar(valorSaque);

            _repository.Salvar(conta);

            return conta.Saldo;
        }

        public decimal Depositar(int numeroConta, decimal valorDeposito)
        {
            var conta = ObterConta(numeroConta);

            conta.Depositar(valorDeposito);

            _repository.Salvar(conta);

            return conta.Saldo;
        }
    }
}