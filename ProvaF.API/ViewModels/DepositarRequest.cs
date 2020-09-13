using System.ComponentModel.DataAnnotations;

namespace ProvaF.API.ViewModels
{
    public class DepositarRequest
    {
        [Required]
        public decimal Valor { get; set; }
    }
}