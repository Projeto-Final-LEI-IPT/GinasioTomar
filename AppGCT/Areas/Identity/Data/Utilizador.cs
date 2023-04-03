using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AppGCT.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Utilizador class
public class Utilizador : IdentityUser
{

    [PersonalData]

    public string? Nome { get; set; }
    [PersonalData]
    public string? NIF { get; set; }
}

