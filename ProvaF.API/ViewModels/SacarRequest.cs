using System.ComponentModel.DataAnnotations;

namespace ProvaF.API.ViewModels
{
    public class SacarRequest
    {
        [Required]
        public decimal Valor { get; set; }
    }
}