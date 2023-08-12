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
    public string Nome { get; set; }
    [PersonalData]
    public string NumSocio { get; set; }
    public string NIF { get; set; }
    public string EstadoUtilizador { get; set; }
    public string RoleAux { get; set; }
    [PersonalData]
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
    public string? IdCriacao { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DataModificacao { get; set; }
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

