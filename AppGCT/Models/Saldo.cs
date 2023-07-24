using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Saldo
    {
        [Key]
        [Display(Name = "Sócio")]
        [Required(ErrorMessage = "Sócio é campo obrigatório!")]
        [StringLength(36)]
        public string IdSocio { get; set; }

        [DataType(DataType.Currency)]
        [Precision(18, 2)]
        [Display(Name = "Saldo")]

        public Decimal? MSaldo { get; set; }
    }
}
