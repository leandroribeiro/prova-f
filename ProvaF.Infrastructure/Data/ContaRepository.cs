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
        public Task<Conta> ObterAsync(int numeroConta)
        {
            return _context.Contas.FirstOrDefaultAsync(x => x.Id == numeroConta);
        }
        
    }
}