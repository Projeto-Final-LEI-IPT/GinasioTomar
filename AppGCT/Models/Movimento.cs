using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppGCT.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Models
{
    public class Movimento
    {
        [Key]
        [Display(Name = "Identificação do Movimento")]
        public Guid? Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Descrição da Rúbrica tem de ter entre 5 e 30 caracteres")]
        [Display(Name = "Descrição da Rúbrica")]
        public string? DesRubrica { get; set; }

        [Required(ErrorMessage = "Data de Movimento é campo obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de movimento")]
        public DateTime DtMovimento { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valores entre 0,00€ e 301,00€")]
        [Range(0, 300.00, ErrorMessage = "Valores entre 0,00€ e 302,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Movimento")]
        public Decimal? ValorMovimento { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 150.00, ErrorMessage = "Valores entre 0,00€ e 150,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Desconto")]
        public Decimal? ValorDesconto { get; set; }

        [DataType((DataType.Text))]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Número de Fatura tem de ter entre 5 e 15 caracteres")]
        [Display(Name = "Número de Fatura")]
        public string? NumFatura { get; set; }

        [DataType((DataType.Text))]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Número de Nota de Crédito tem de ter entre 5 e 15 caracteres")]
        [Display(Name = "Número de Nota de Crédito")]
        public string? NumNotaCredito { get; set; }

        [DataType(DataType.Currency)]
        [Precision(18, 2)]
        [Display(Name = "Saldo")]
        public Decimal? MSaldo { get; set; }

        [DataType((DataType.Text))]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Observações tem de ter entre 5 e 100 caracteres")]
        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        [DataType((DataType.Date))]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Criado por")]
        [StringLength(36)]
        public string? IdCriacao { get; set; }
        [DataType((DataType.Date))]
        [Display(Name = "Data de Modificação")]
        public DateTime DataModificacao { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Modificado por")]
        [StringLength(36)]
        public string? IdModificacao { get; set; }
        [Display(Name = "Número de Sócio")]

        /// <summary>
        /// Chave Forasteira com tabela UTILIZADOR ( --- preenchimento obrigatório --- )
        /// </summary>
        public string UtilizadorId { get; set; }

        [Display(Name = "Sócio")]

        public Utilizador? Socio { get; set; }

        /// <summary>
        /// Chave Forasteira com tabela GINASTA ( --- preenchimento opcional --- )
        /// </summary>
        public int? AtletaMovimentoId { get; set; }
        [Display(Name = "Ginasta")]
        public Ginasta? Atleta { get; set; }

        /// <summary>
        /// Chave Forasteira com tabela GINASTA ( --- preenchimento obrigatório --- )
        /// </summary>
        [Required(ErrorMessage = "Rúbrica é campo obrigatório!")]
        public string RubricaId { get; set; }
        [Display(Name = "Rúbrica")]
        public Rubrica? TipoDespesa { get; set; }

        /// <summary>
        /// Chave Forasteira com tabela MetodoPagamento ( --- preenchimento opcional --- )
        /// </summary>
        public string? MetodoPagamentoId { get; set; }
        [Display(Name = "Método de Pagamento")]
        public MetodoPagamento? FormaPagamento { get; set; }

    }
}
