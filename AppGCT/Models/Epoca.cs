using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Epoca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEpoca { get; set; }
        [Required(ErrorMessage = "Época é campo obrigatório!")]
        [Display(Name = "Época")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Época tem de ter exatamente 9 caracteres(Ex:2023/2024)")]
        public string? NomeEpoca { get; set; }
        [Required(ErrorMessage = "Data Inicio é campo obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "Data Fim é campo obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Fim")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Estado")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Estado do Desconto deverá ser (A) Ativa, (C) Cancelado ou (F) Finalizada")]
        public string? EstadoEpoca { get; set; }
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
        public string StatusDescription
        {
            get
            {
                switch (this.EstadoEpoca)
                {
                    case "A":
                        return "Ativa";
                    case "C":
                        return "Cancelada";
                    case "F":
                        return "Finalizada";
                    default:
                        return "Desconhecido";
                }
            }
        }

        public List<Inscricao>? Inscricoes { get; set; }

        public List<PlanoMensalidade>? Planos { get; set; }
    }



}
