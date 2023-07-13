using AppGCT.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Rubrica
    {
        [Key]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Código Rúbrica tem de ter 3 caracteres")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Código Rúbrica é campo obrigatório!")]
        [Display(Name = "Código")]
        public string? CodRubrica { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição Rúbrica é campo obrigatório!")]
        [DataType(DataType.Text)]
        public string? DescricaoRubrica { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Estado Rúbrica é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Estado da Rúbrica deverá ser (A) Ativo ou (I) Inativo")]
        [DataType(DataType.Text)]
        public string? EstadoRubrica { get; set; }

        [Display(Name = "Movimento")]
        [Required(ErrorMessage = "Tipo Movimento é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Tipo Movimento deverá ser (C) Crédito ou (D) Débito")]
        [DataType(DataType.Text)]
        public string? TipoMovimento { get; set; }

        [Display(Name = "Presente no Preçário público?")]
        [Required(ErrorMessage = "Indicador Preçário Público é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Indicador Preçário Público deverá ser (S) Sim ou (N) Não")]
        [DataType(DataType.Text)]
        public string? IPrecario { get; set; }

        [Display(Name = "Ordem no Preçário público")]
        [DataType(DataType.Text)]
        public int? OrdemPrecario { get; set; }

        [Display(Name = "Tem valor unitário?")]
        [Required(ErrorMessage = "Indicador valor unitário é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Indicador valor unitário deverá ser (S) Sim ou (N) Não")]
        [DataType(DataType.Text)]
        public string? IVlrUnit { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 500.00, ErrorMessage = "Valores entre 0,00€ e 500,00€")]
        [Precision(18, 2)]
        [Display(Name = "Valor Unitário")]
        public Decimal? ValorUnitario { get; set; }

        [Display(Name = "Cobrar na inscrição?")]
        [Required(ErrorMessage = "Indicador Pagamento na Inscrição é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Indicador valor unitário deverá ser (S) Sim ou (N) Não")]
        [DataType(DataType.Text)]
        public string? IPagInscricao { get; set; }

        [Display(Name = "Tipo Rúbrica")]
        [Required(ErrorMessage = "Tipo Rúbrica é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Tipo Rúbrica deverá ser (P) Pagamento, (D) Devoluções ou (O) Outros")]
        [DataType(DataType.Text)]
        public string? TipoRubrica { get; set; }

        [Display(Name = "Local de treino - Pavilhão")]
        [StringLength(50, ErrorMessage = "Local de treino não pode exceder 50 caracteres")]
        [DataType(DataType.Text)]
        public string? LocalTreino { get; set; }

        [Display(Name = "Horário")]
        [StringLength(50, ErrorMessage = "Horário não pode exceder 50 caracteres")]
        [DataType(DataType.Text)]
        public string? Horario { get; set; }

        [Display(Name = "Horas semanais")]
        [StringLength(6, ErrorMessage = "Horas semanais não pode exceder 6 caracteres (ex:12h00m")]
        [DataType(DataType.Text)]
        public string? HorasSemanais { get; set; }

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


        public string DescricaoEstadoRubrica
        {
            get
            {
                switch (this.EstadoRubrica)
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

        public string DescricaoTipoMovimento
        {
            get
            {
                switch (this.TipoMovimento)
                {
                    case "C":
                        return "Crédito";
                    case "D":
                        return "Débito";
                    default:
                        return "Desconhecido";
                }
            }
        }
        
        public string DescricaoIPrecario
        {
            get
            {
                switch (this.IPrecario)
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

        public string DescricaoIVlrUnit
        {
            get
            {
                switch (this.IVlrUnit)
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

        public string ID_DescriptionRubrica
        {
            get
            {
                return string.Format("{0} {1}", CodRubrica, DescricaoRubrica);
            }
        }
        public string DescricaoIPagInscricao
        {
            get
            {
                switch (this.IPagInscricao)
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

        public string DescricaoTipoRubrica
        {
            get
            {
                switch (this.TipoRubrica)
                {
                    case "P":
                        return "Pagamentos";
                    case "D":
                        return "Devoluções";
                    case "O":
                        return "Outros";
                    default:
                        return "Desconhecido";
                }
            }
        }

        public string? DescontoId { get; set; }
        public Desconto? Discount { get; set; }

        public int? ClasseId { get; set; }
        public Classe? Modalidade { get; set; }

        public List<Movimento>? Movimentos { get; set; }
    }
}
