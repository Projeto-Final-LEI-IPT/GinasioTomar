using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Models
{
    public class Ginasta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identificação do Ginasta")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome Completo é campo obrigatório!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome Completo tem de ter pelo menos 5 caracteres")]
        [DataType(DataType.Text)]
        [Display(Name = "Nome Completo")]
        public string? NomeCompleto { get; set; }

        [Required(ErrorMessage = "Sexo é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Nome Completo tem de ter pelo menos 1 caracter (M) ou (F)")]
        [DataType(DataType.Text)]
        [Display(Name = "Sexo")]
        public string? ISexo { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é campo obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DtNascim { get; set; }

        [DataType((DataType.ImageUrl))]
        [Display(Name = "Foto")]
        public byte[]? Foto { get; set; }

        [Required(ErrorMessage = "Estado Ginasta é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Estado Ginasta tem de ter pelo menos 1 caracter (A) ou (I)")]
        [DataType((DataType.Text))]
        [Display(Name = "Estado Ginasta")]
        public string? EstadoGinasta { get; set; }

        [Required(ErrorMessage = "Cartão Cidadão é campo obrigatório!")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Cartão de cidadão tem de ter entre 8 a 9 digitos numéricos.")]
        [RegularExpression(@"^[0-9]{8,9}$", ErrorMessage = "Cartão de cidadão só aceita números entre 0 e 9")]
        [DataType((DataType.Text))]
        [Display(Name = "Cartão Cidadão")]
        public string? NumCC { get; set; }

        [Required(ErrorMessage = "NIF é campo obrigatório!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "NIF tem de ter 9 digitos numéricos.")]
        [RegularExpression(@"^(1\d{8}|[2-3]\d{8}|45\d{7})$", ErrorMessage = "NIF inválido.")]
        [DataType((DataType.Text))]
        [Display(Name = "NIF")]
        public string? NIF { get; set; }

        [Required(ErrorMessage = "NISS ou ADSE é campo obrigatório!")]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "NISS ou ADSE tem de ter 11 (12 para ADSE) digitos numéricos.")]
        [RegularExpression(@"^[0-9]{11,12}$", ErrorMessage = "NISS ou ADSE só aceita números entre 0 e 9")]
        [DataType((DataType.Text))]
        [Display(Name = "NISS ou ADSE")]
        public string? NISS { get; set; }

        [Required(ErrorMessage = "Morada é campo obrigatório!")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Morada tem de ter pelo menos 10 caracteres")]
        [DataType((DataType.Text))]
        [Display(Name = "Morada")]
        public string? Morada { get; set; }

        [RegularExpression(@"^[0-9]{4}-[0-9]{3}$", ErrorMessage = "Código Postal deve obedecer ao seguinte critério XXXX-YYY")]
        [StringLength(8)]
        [DataType((DataType.Text))]
        [Display(Name = "Código Postal")]
        public string? CodPostal { get; set; }

        [StringLength(20)]
        [DataType((DataType.Text))]
        [Display(Name = "Localidade")]
        public string? Localidade { get; set; }

        [Required(ErrorMessage = "Bolsa é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Bolsa tem de ter pelo menos 1 caracter (S) ou (N)")]
        [DataType((DataType.Text))]
        [Display(Name = "Bolsa")]
        public string? IBolsa { get; set; }

        [Required(ErrorMessage = "Irmãos é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Irmãos tem de ter pelo menos 1 caracter (S) ou (N)")]
        [DataType((DataType.Text))]
        [Display(Name = "Irmãos")]
        public string? IIrmaos { get; set; }

        [StringLength(50)]
        [DataType((DataType.Text))]
        [Display(Name = "Nome(s) Irmão(s)")]
        public string? NomeIrmaos { get; set; }

        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email Ginasta inválido")]
        [DataType((DataType.Text))]
        [Display(Name = "Email Ginasta")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Nome EE é campo obrigatório!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome EE tem de ter pelo menos 5 caracteres")]
        [DataType((DataType.Text))]
        [Display(Name = "Nome EE")]
        public string? NomeEE { get; set; }

        [Required(ErrorMessage = "NIF EE é campo obrigatório!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "NIF EE tem de ter 9 digitos numéricos.")]
        [RegularExpression(@"^(1\d{8}|[2-3]\d{8}|45\d{7})$", ErrorMessage = "NIF EE inválido.")]
        [DataType((DataType.Text))]
        [Display(Name = "NIF EE")]
        public string? NIFEE { get; set; }

        [StringLength(6)]
        [RegularExpression(@"^\+\d{1,5}$", ErrorMessage = " Prefixo Tlm. EE tem de estar no formato +XXXXX em que X são números entre 0 e 9")]
        [DataType((DataType.Text))]
        [Display(Name = "Prefixo Tlm. EE")]
        public string? prefixoTelemEE { get; set; }

        [Required(ErrorMessage = "Tlm. EE é campo obrigatório!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Tlm. EE tem de ter 9 digitos numéricos")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Tlm. EE só aceita números entre 0 e 9")]
        [DataType((DataType.Text))]
        [Display(Name = "Tlm. EE")]
        public string? numTelemovelEE { get; set; }

        [Required(ErrorMessage = "Grau Parentesco EE é campo obrigatório!")]
        [StringLength(10)]
        [DataType((DataType.Text))]
        [Display(Name = "Grau Parentesco (EE)")]
        public string? IGrauEE { get; set; }

        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email EE inválido")]
        [DataType((DataType.Text))]
        [Display(Name = "Email EE")]
        public string? EmailEE { get; set; }

        [StringLength(50)]
        [DataType((DataType.Text))]
        [Display(Name = "Nome (Emergência)")]
        public string? NomeEmerEE { get; set; }

        [StringLength(10)]
        [DataType((DataType.Text))]
        [Display(Name = "Grau Parentesco (Emergência)")]
        public string? GrauEmerEE { get; set; }

        [StringLength(6)]
        [RegularExpression(@"^\+\d{1,5}$", ErrorMessage = " Prefixo Tlm. Emer. tem de estar no formato +XXXXX em que X são números entre 0 e 9")]
        [DataType((DataType.Text))]
        [Display(Name = "Prefixo Tlm. (Emergência)")]
        public string? PrefixoTlmEmerEE { get; set; }

        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Tlm. Emergência só aceita números entre 0 e 9")]
        [DataType((DataType.Text))]
        [Display(Name = "Tlm. (Emergência)")]
        [StringLength(9)]
        public string? NumTlmEmerEE { get; set; }

        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email Emergência inválido")]
        [DataType((DataType.Text))]
        [Display(Name = "Email (Emergência)")]
        public string? EmailTlmEmerEE { get; set; }

        [DataType((DataType.Date))]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [StringLength(36)]
        [DataType((DataType.Text))]
        [Display(Name = "Criado por")]
        public string? IdCriacao { get; set; }

        [DataType((DataType.Date))]
        [Display(Name = "Data de Modificação")]
        public DateTime DataModificacao { get; set; }

        [StringLength(36)]
        [DataType((DataType.Text))]
        [Display(Name = "Modificado por")]
        public string? IdModificacao { get; set; }

        //[StringLength(36)]
        //não pode ser apenas de tamanho 36 por causa do tamanho definido no Identity (aspnetusers.id) chave estrangeira
        [Display(Name = "Número de Sócio")]
        public string UtilizadorId { get; set; }

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

        public string ID_DescrGinastaSocio
        {
            get
            {
                return string.Format("{0} - Sócio: {1}", NomeCompleto, Socio);
            }
        }
        [Display(Name = "Ginasta ")]

        public Utilizador? Socio { get; set; }

        public List<Inscricao>? Inscricoes { get; set; }

        public List<Movimento>? Movimentos { get; set; } = new List<Movimento>();

        public List<PlanoMensalidade>? Planos { get; set; }
    }
}
