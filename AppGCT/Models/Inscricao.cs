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

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data Inscrição")]
        public DateTime DtInscricao { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Consentimento RGPD")]
        public string? IConsentimento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data Consentimento")]
        public DateTime DtConsentimento { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Ex. Médico Efetuado")]
        public string? IExamMed { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Ex. Médico")]
        public DateTime DtExamMed { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Ficha FGP")]
        public string? IFicFGP { get; set; }
       
        [DataType(DataType.Date)]
        [Display(Name = "Data ficha FGP")]
        public DateTime DtFicFGP { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Seguro")]
        public string? ISeguro { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Pagamento Inscrição")]
        public string? IPagamInscricao { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Leitura Obrigatória")]
        public string? ILeituraObrig { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Fotos")]
        public string? IFotos { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ibuprofeno")]
        public string? IIbuprofeno { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Paracetamol")]
        public string? IParacetamol { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Anti-Inflamatório")]
        public string? IAntiInflam { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Alergias")]
        public string? DescAlergias { get; set; }

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

        public int GinastaId { get; set; }

        public Ginasta? Atleta { get; set; }

        public int EpocaId { get; set; }

        public Epoca? Periodo { get; set; }
    }
}
