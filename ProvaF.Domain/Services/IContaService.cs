using System.Threading.Tasks;

namespace ProvaF.Domain.Services
{
    public interface IContaService
    {
        decimal ObterSaldo(int numeroConta);
        decimal Sacar(int numeroConta, decimal valorSaque);
        decimal Depositar(int numeroConta, decimal valorDeposito);
    }
}