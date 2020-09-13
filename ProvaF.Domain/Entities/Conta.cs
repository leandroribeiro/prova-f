namespace ProvaF.Domain.Entities
{
    public class Conta
    {
        public decimal Saldo { get; set; }
        public int Id { get; set; }

        public void Sacar(decimal valorSaque)
        {
            this.Saldo -= valorSaque;
        }
    }
}