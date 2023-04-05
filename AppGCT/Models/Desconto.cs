using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Desconto
    {
        [Key]
        [StringLength(2, MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Código Desconto")]
        public String? CodDesconto { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição Desconto")]
        public String? DescDesconto { get; set; }

        [Display(Name = "Estado Desconto")]
        [StringLength(1, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string? EstadoDesconto { get; set; }

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
    }
}
