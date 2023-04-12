using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Models
{
    public class Ginasta
    {
        public int? Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nome Completo")]
        public string? NomeCompleto { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Sexo")]
        public string? ISexo { get; set; }

        public string UtilizadorId { get; set; }

        public Utilizador? Socio { get; set; }

        public List<Inscricao>? inscricao { get; set; }
    }
}
