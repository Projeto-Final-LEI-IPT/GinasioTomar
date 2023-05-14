using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Epoca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEpoca { get; set; }
        [Required]
        [Display(Name = "Época")]
        public string? NomeEpoca { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Fim")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Estado")]
        public string? EstadoEpoca { get; set; }
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [Display(Name = "Criado por")]
        public string? IdCriacao { get; set; }
        [Display(Name = "Data de Modificação")]
        public DateTime? DataModificacao { get; set; }
        [Display(Name = "Modificado por")]
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
    }



}
