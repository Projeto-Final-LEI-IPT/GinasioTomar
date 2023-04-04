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
        public string? NomeEpoca { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }
        public string? EstadoEpoca { get; set; }

        public DateTime DataCriacao { get; set; }
        public string? IdCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }
        public string? IdModificacao { get; set; }
    }
}
