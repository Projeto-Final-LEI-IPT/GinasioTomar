using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGCT.Models
{
    public class PlanoMensalidades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlanoM { get; set; }

        [Required(ErrorMessage = "Data Mensalidade é campo obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Mensalidade")]
        public DateTime DataMensalidade { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 500.00, ErrorMessage = "Valores entre 0,00€ e 500,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Mensalidade")]
        public Decimal? ValorMensalidade { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Criado por")]
        [StringLength(36)]
        public string? IdCriacao { get; set; }

        [Display(Name = "Data de Modificação")]
        public DateTime? DataModificacao { get; set; }

        [Display(Name = "Modificado por")]
        [StringLength(36)]
        public string? IdModificacao { get; set; }

    }
}
