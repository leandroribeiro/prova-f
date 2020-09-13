using System.Threading.Tasks;
using ProvaF.Domain.Entities;

namespace ProvaF.Domain.Repositories
{
    public interface IContaRepository
    {
        Conta Obter(int numeroConta);
        bool Salvar(Conta conta);
    }
}