using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdClasse { get; set; }
        [Required(ErrorMessage = "Nome da Classe é campo obrigatório!")]
        [Display(Name = "Classe")]
        [StringLength(50, ErrorMessage = "Nome da Classe não pode exceder 50 caracteres")]
        public string? NomeClasse { get; set; }
        [Display(Name = "Estado Classe")]
        [StringLength(1, ErrorMessage = "Estado da Classe deverá ser (A) Ativa ou (I) Inativa")]
        public string? EstadoClasse { get; set; }
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
        public string EstadoClasseDescricao
        {
            get
            {
                switch (this.EstadoClasse)
                {
                    case "A":
                        return "Ativa";
                    case "I":
                        return "Inativa";
                    default:
                        return "Desconhecido";
                }
            }
        }

        public List<Inscricao>? Inscricoes { get; set; }
        public List<Rubrica>? Rubricas { get; set; } = new List<Rubrica>();
    }
}
