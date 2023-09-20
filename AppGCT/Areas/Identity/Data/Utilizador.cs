using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AppGCT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;

namespace AppGCT.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Utilizador class
public class Utilizador : IdentityUser
{
    [PersonalData]
    [Required(ErrorMessage = "Nome Completo é campo obrigatório!")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome Completo tem de ter minimo 5 e máximo 50 caracteres")]
    [DataType(DataType.Text)]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [PersonalData]
    [StringLength(10)]
    [DataType(DataType.Text)]
    [Display(Name = "Nº Sócio")]
    public string NumSocio { get; set; }

    [Required(ErrorMessage = "NIF é campo obrigatório!")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "NIF tem de ter 9 digitos numéricos.")]
    [RegularExpression(@"^(1\d{8}|[2-3]\d{8}|45\d{7})$", ErrorMessage = "NIF inválido.")]
    [DataType((DataType.Text))]
    [Display(Name = "NIF")]
    public string NIF { get; set; }

    [StringLength(1)]
    [DataType(DataType.Text)]
    [Display(Name = "Estado Utilizador")]
    public string EstadoUtilizador { get; set; }

    [Required(ErrorMessage = "Código Postal é campo obrigatório!")]
    [RegularExpression(@"^[0-9]{4}-[0-9]{3}$", ErrorMessage = "Código Postal deve obedecer ao seguinte critério XXXX-YYY")]
    [StringLength(8)]
    [DataType((DataType.Text))]
    [Display(Name = "Código Postal")]
    public string CodPostal { get; set; }

    [StringLength(15)]
    [DataType(DataType.Text)]
    [Display(Name = "Role Aux")]
    public string RoleAux { get; set; }

    [PersonalData]
    [Required(ErrorMessage = "Morada é campo obrigatório!")]
    [StringLength(50, MinimumLength = 15, ErrorMessage = "Morada tem de ter entre 15 e 50 caracteres.")]
    [DataType(DataType.Text)]
    [Display(Name = "Morada")]
    public string Morada { get; set; }

    [PersonalData]
    [DataType(DataType.Date)]
    public DateTime DataNascim { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DataAprovacao { get; set; }
    public DateTime? UltimoLogin { get; set; }
    [PersonalData]
    [DataType(DataType.Date)]
    public DateTime DataCriacao { get; set; }
    [StringLength(36)]
    public string? IdCriacao { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DataModificacao { get; set; }
    [StringLength(36)]
    public string? IdModificacao { get; set; }
    public string ID_Description
    {
        get
        {
            return string.Format("{0} ({1})", Nome, NumSocio);
        }
    }
    public List<Ginasta> Ginasta { get; set; }

    public List<Movimento> Movimentos { get; set; }

    public string StatusDescription
    {
        get
        {
            switch (this.EstadoUtilizador)
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
}

