using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaF.API.ViewModels
{
    public class SacarResponse
    {
        public SacarResponse(int numero, decimal saldo)
        {
            this.Conta = numero;
            this.Saldo = saldo;
        }

        public int Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
