using AppGCT.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Inscricao
    {
        public int? Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Numero FGPo")]
        public string? IdFGP { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Numero Ginasta")]
        public string? ISocGinasta { get; set; }

        public int GinastaId { get; set; }

        public Ginasta? Atleta { get; set; }
    }
}
