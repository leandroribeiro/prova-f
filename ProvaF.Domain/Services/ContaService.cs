using System;
using System.Threading.Tasks;
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

        public decimal ObterSaldo(int numeroConta)
        {
            var conta = _repository.ObterAsync(numeroConta).Result;

            return conta.Saldo; ;
        }

        public decimal Sacar(int numeroConta, decimal valorSaque)
        {
            throw new NotImplementedException();
        }
    }
}