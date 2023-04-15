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

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DtNascim { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Idade em Agosto")]
        public string? IdadeAgosto { get; set; }
        [DataType((DataType.ImageUrl))]
        [Display(Name = "Foto")]
        public string? Foto { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Estado Ginasta")]
        public string? EstadoGinasta { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Cartão Cidadão")]
        public string? NumCC { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "NIF")]
        public string? NIF { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "NISS")]
        public string? NISS { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Morada")]
        public string? Morada { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Código Postal")]
        public string? CodPostal { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Localidade")]
        public string? Localidade { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Bolsa")]
        public string? IBolsa { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Irmãos")]
        public string? IIrmaos { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Nome de Irmãos")]
        public string? NomeIrmaos { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Enc. Educação")]
        public string? NomeEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "NIF Enc. Edu.")]
        public string? NIFEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Prefixo Tlm. EE")]
        public string? prefixoTelemEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Tlm. EE")]
        public string? numTelemovelEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Grau Enc. Edu.")]
        public string? IGrauEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Email Enc. Edu.")]
        public string EmailEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Nome Emerg. Enc. Edu.")]
        public string? NomeEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Grau Emerg. Enc. Edu.")]
        public string? GrauEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Prefixo Tlm. Emerg. Enc. Edu.")]
        public string? PrefixoTlmEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Tlm. Emerg. Enc. Edu.")]
        public string? NumTlmEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Email Emerg. Enc. Edu.")]
        public string? EmailTlmEmerEE { get; set; }
        [Required]
        [DataType((DataType.Date))]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [Required]
        [DataType((DataType.Text))]
        [Display(Name = "Criado por")]
        public string? IdCriacao { get; set; }
        [DataType((DataType.Date))]
        [Display(Name = "Data de Modificação")]
        public DateTime? DataModificacao { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Modificado por")]
        public string? IdModificacao { get; set; }
        [Display(Name = "Número de Sócio")]
        public string UtilizadorId { get; set; }
        [Display(Name = "Número de Sócio")]

        public string ID_DescrGinasta
        {
            get
            {
                return string.Format("{0} ({1})", NomeCompleto, NIF);
            }
        }

        public Utilizador? Socio { get; set; }

        public List<Inscricao>? inscricao { get; set; }
    }
}
