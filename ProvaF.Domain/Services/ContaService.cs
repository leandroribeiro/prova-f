using System;
using System.Threading.Tasks;
using ProvaF.Domain.Entities;
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

            //TODO
            if (conta == null)
                throw new ArgumentOutOfRangeException();
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

    }
}