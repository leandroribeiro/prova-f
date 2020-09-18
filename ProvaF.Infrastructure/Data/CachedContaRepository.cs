using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ProvaF.Domain.Entities;
using ProvaF.Domain.Repositories;

namespace ProvaF.Infrastructure.Data
{
    public class CachedContaRepository : IContaRepository
    {
        private readonly IContaRepository _repository;

        private readonly IDistributedCache _cache;

        public CachedContaRepository(IContaRepository repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }
        public Conta Obter(int numeroConta)
        {
            var cachedData = _cache.Get(numeroConta.ToString());
                
            if (cachedData != null)
            {
                var binaryData = Encoding.UTF8.GetString(cachedData);
                var resultItem = JsonConvert.DeserializeObject<Conta>(binaryData);
                    
                return resultItem;
            }
            else
            {
                var conta = _repository.Obter(numeroConta);

                AdicionarNoCache(numeroConta, conta);

                return conta;
            }
        }

        private void AdicionarNoCache(int numeroConta, Conta conta)
        {
            var serializeData = JsonConvert.SerializeObject(conta);
            var binaryData = Encoding.UTF8.GetBytes(serializeData);

            _cache.SetAsync(numeroConta.ToString(), binaryData);
        }

        public bool Salvar(Conta conta)
        {
            if (!_repository.Salvar(conta)) 
                return false;
            
            AdicionarNoCache(conta.Id, conta);
            
            return true;

        }
    }
}