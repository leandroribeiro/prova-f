using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaF.Domain.Entities;
using ProvaF.Domain.Repositories;

namespace ProvaF.Infrastructure.Data
{
    public class ContaRepository : BaseRepository, IContaRepository
    {
        public ContaRepository(ProvaFDbContext context) : base(context)
        {
            
        }
        public Conta Obter(int numeroConta)
        {
            return _context.Contas.FirstOrDefault(x => x.Id == numeroConta);
        }

        public bool Salvar(Conta conta)
        {
            _context.Contas.Update(conta);
            
            var registrosAfetados = _context.SaveChanges();

            return registrosAfetados > 0;
        }
    }
}