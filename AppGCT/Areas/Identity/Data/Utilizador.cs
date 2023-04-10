using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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
}

