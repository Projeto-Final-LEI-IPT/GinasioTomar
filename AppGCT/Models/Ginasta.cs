using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Models
{
    public class Ginasta
    {
        [Display(Name = "Identificação do Ginasta")]
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
        [DataType((DataType.ImageUrl))]
        [Display(Name = "Foto")]
        public byte[]? Foto { get; set; }
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
        [Display(Name = "NISS ou ADSE")]
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
        [Display(Name = "Nome(s) Irmão(s)")]
        public string? NomeIrmaos { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Email Ginasta")]
        public string? Email { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Nome EE")]
        public string? NomeEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "NIF EE")]
        public string? NIFEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Prefixo Tlm. EE")]
        public string? prefixoTelemEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Tlm. EE")]
        public string? numTelemovelEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Grau Parentesco (EE)")]
        public string? IGrauEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Email EE")]
        public string EmailEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Nome (Emergência)")]
        public string? NomeEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Grau Parentesco (Emergência)")]
        public string? GrauEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Prefixo Tlm. (Emergência)")]
        public string? PrefixoTlmEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Tlm. (Emergência)")]
        public string? NumTlmEmerEE { get; set; }
        [DataType((DataType.Text))]
        [Display(Name = "Email (Emergência)")]
        public string? EmailTlmEmerEE { get; set; }
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
        [Display(Name = "Número de Sócio")]
        public string UtilizadorId { get; set; }
        [Display(Name = "Número de Sócio")]
        public string StatusDescription
        {
            get
            {
                switch (this.EstadoGinasta)
                {
                    case "A":
                        return "Ativo";
                    case "P":
                        return "Pré-Ativo";
                    case "I":
                        return "Inativo";
                    default:
                        return "Desconhecido";
                }
            }
        }
        public string ID_DescrGinasta
        {
            get
            {
                return string.Format("{0} (CC: {1})", NomeCompleto, NumCC);
            }
        }
        [Display(Name = "Ginasta")]

        public Utilizador? Socio { get; set; }

        public List<Inscricao>? Inscricoes { get; set; }
        /// <summary>
        /// Ligação com tabela Movimento --- Não esquecer que o preenchimento do Ginasta é Opcional ---
        /// </summary>
        public List<Movimento>? Movimentos { get; set; } = new List<Movimento>();

        public List<PlanoMensalidade>? Planos { get; set; }
    }
}
