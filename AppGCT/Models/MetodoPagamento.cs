using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGCT.Models
{
    public class MetodoPagamento
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Código Método Pagamento tem de ter 2 caracteres")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Código Método Pagamento é campo obrigatório!")]
        [Display(Name = "Código Método Pagamento")]
        public String? CodMetodo { get; set; }

        [Required(ErrorMessage = "Descrição Método Pagamento é campo obrigatório!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Descrição do Método Pagamento tem de ter pelo menos 5 caracteres")]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição Método Pagamento")]

        public String? DescMetodo { get; set; }
        [DataType(DataType.Currency)]
        [Range(0, 20.00, ErrorMessage = "Valores entre 0,00€ e 20,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Desconto")]

        public Decimal? ValorDesconto { get; set; }

        [Display(Name = "Estado Método Pagamento")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Estado do Desconto deverá ser (A) Ativo ou (I) Inativo")]
        [DataType(DataType.Text)]
        public string? EstadoMetodo { get; set; }

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
        public string EstadoMetodoDescricao
        {
            get
            {
                switch (this.EstadoMetodo)
                {
                    case "A":
                        return "Ativo";
                    case "I":
                        return "Inativo";
                    default:
                        return "Desconhecido";
                }
            }
        }
    }
}
