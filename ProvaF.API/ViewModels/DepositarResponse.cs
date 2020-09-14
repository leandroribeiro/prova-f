using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaF.API.ViewModels
{
    public class DepositarResponse
    {

        public DepositarResponse(int numero, decimal saldo)
        {
            this.Conta = numero;
            this.Saldo = saldo;
        }

        public int Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
