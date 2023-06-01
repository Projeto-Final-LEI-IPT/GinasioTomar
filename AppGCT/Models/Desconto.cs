using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace AppGCT.Models
{
    public class Desconto
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Código Desconto tem de ter 2 caracteres")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Código Desconto é campo obrigatório!")]
        [Display(Name = "Código Desconto")]
        public String CodDesconto { get; set; }

        [Required(ErrorMessage = "Descrição Desconto é campo obrigatório!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Descrição do Desconto tem de ter pelo menos 5 caracteres")]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição Desconto")]

        public String? DescDesconto { get; set; }

        [Display(Name = "Estado Desconto")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Estado do Desconto deverá ser (A) Ativo ou (I) Inativo")]
        [DataType(DataType.Text)]
        public string? EstadoDesconto { get; set; }

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
                switch (this.EstadoDesconto)
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

        public List<Rubrica>? Rubricas { get; set; } = new List<Rubrica>();
    }
}
