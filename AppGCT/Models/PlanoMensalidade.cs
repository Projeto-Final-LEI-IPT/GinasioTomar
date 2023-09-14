using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGCT.Models
{
    public class PlanoMensalidade
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

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Lançado")]
        public string? ILancado { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 500.00, ErrorMessage = "Valores entre 0,00€ e 500,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Mensalidade Lançado")]
        public Decimal? ValorMensalidadeLanc { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Id Movimento")]
        public Guid? IdMovimento { get; set; }

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

        public string ILancadoDescricao
        {
            get
            {
                switch (this.ILancado)
                {
                    case "S":
                        return "Sim";
                    case "N":
                        return "Não";
                    default:
                        return "Desconhecido";
                }
            }
        }

        public int EpocaId { get; set; }

        public Epoca? Epoca { get; set; }

        public int GinastaId { get; set; }

        public Ginasta? Aluno { get; set; }

    }
}
