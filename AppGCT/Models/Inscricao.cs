﻿using AppGCT.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGCT.Models
{
    public class Inscricao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identificação Inscrição")]
        public int? Id { get; set; }

        [StringLength(15)]
        [DataType(DataType.Text)]
        [Display(Name = "FGP Nº")]
        public string? IdFGP { get; set; }

        [Required(ErrorMessage = "Sócio/Ginasta é campo obrigatório!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Sócio/Ginasta tem de ter pelo menos 1 caracter (S) ou (N)")]
        [DataType(DataType.Text)]
        [Display(Name = "Sócio-Ginasta")]
        public string? ISocGinasta { get; set; }

        [Required(ErrorMessage = "Data Inscrição é campo obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Inscrição")]
        public DateTime DtInscricao { get; set; }

        [DataType((DataType.Text))]
        [Display(Name = "Idade a 31 de Agosto")]
        public int? IdadeAgosto { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Consentimento de Dados")]
        public string? IConsentimento { get; set; }

        [Required(ErrorMessage = "Data Consentimento de dados é campo obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Consentimento de dados")]
        public DateTime DtConsentimento { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Exame Médico Desportivo")]
        public string? IExamMed { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Exame Médico Desportivo")]
        public DateTime DtExamMed { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ficha individual FGP")]
        public string? IFicFGP { get; set; }
       
        [DataType(DataType.Date)]
        [Display(Name = "Data Ficha individual FGP")]
        public DateTime DtFicFGP { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Pagamento do Seguro")]
        public string? ISeguro { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Pagamento da Inscrição")]
        public string? IPagamInscricao { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Entrega dos documentos de leitura obrigatória")]
        public string? ILeituraObrig { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Autoriza fotos/filmagens")]
        public string? IFotos { get; set; }

        [Required]
        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ibuprofeno")]
        public string? IIbuprofeno { get; set; }

        [Required]
        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Paracetamol")]
        public string? IParacetamol { get; set; }

        [Required]
        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Autoriza toma de Analgésico / Anti-Inflamatório ?")]
        public string? IAntiInflam { get; set; }

        [StringLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "Outras alergias")]
        public string? DescAlergias { get; set; }

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

        public string DescricaoISocGinasta
        {
            get
            {
                switch (this.ISocGinasta)
                {
                    case "S":
                        return "Sim";
                    case "N":
                        return "Não";
                    default:
                        return "Desconhecido";
                }
            }
        }

        public string DescricaoIExamMed
        {
            get
            {
                switch (this.IExamMed)
                {
                    case "S":
                        return "Sim";
                    case "N":
                        return "Não";
                    default:
                        return "Desconhecido";
                }
            }
        }

        public string DescricaoIPagamInscricao
        {
            get
            {
                switch (this.IPagamInscricao)
                {
                    case "S":
                        return "Sim";
                    case "N":
                        return "Não";
                    default:
                        return "Desconhecido";
                }
            }
        }

        public int GinastaId { get; set; }

        public Ginasta? Atleta { get; set; }

        public int EpocaId { get; set; }

        public Epoca? Periodo { get; set; }
        public int ClasseId { get; set; }

        public Classe? Class { get; set; }

        public string? CodDesconto { get; set; }

        public Desconto? Descont { get; set; }

    }
}
