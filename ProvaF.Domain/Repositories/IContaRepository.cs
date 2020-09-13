using System.Threading.Tasks;
using ProvaF.Domain.Entities;

namespace ProvaF.Domain.Repositories
{
    public interface IContaRepository
    {
        Task<Conta> ObterAsync(int numeroConta);
    }
}