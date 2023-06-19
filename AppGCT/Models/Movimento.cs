using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppGCT.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Models
{
    public class Movimento
    {
        [Display(Name = "Identificação do Movimento")]
        public int? Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição da Rúbrica")]
        public string? DesRubrica { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Data de movimento")]
        public DateTime DtMovimento { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 999.00, ErrorMessage = "Valores entre 0,00€ e 999,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Movimento")]
        public Decimal? ValorMovimento { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 20.00, ErrorMessage = "Valores entre 0,00€ e 20,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Desconto")]
        public Decimal? ValorDesconto { get; set; }

        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Número de Fatura")]
        public string? NumFatura { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Número de Nota de Crédito")]
        public string? NumNotaCredito { get; set; }

        [DataType((DataType.Date))]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Criado por")]
        public string? IdCriacao { get; set; }
        [DataType((DataType.Date))]
        [Display(Name = "Data de Modificação")]
        public DateTime DataModificacao { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Modificado por")]
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
        public string RubricaId { get; set; }
        [Display(Name = "Rúbrica")]
        public Rubrica? TipoDespesa { get; set; }

        /// <summary>
        /// Chave Forasteira com tabela MetodoPagamento ( --- preenchimento opcional --- )
        /// </summary>
        public string? MetodoPagamentoId { get; set; }
        [Display(Name = "Método Pagamento")]
        public MetodoPagamento? FormaPagamento { get; set; }
    }
}
