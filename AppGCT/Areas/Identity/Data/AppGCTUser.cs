using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AppGCT.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppGCTUser class
public class AppGCTUser : IdentityUser
{
    [PersonalData]
    public string? Nome { get; set; }
    [PersonalData]
    public string? NIF { get; set; }
}

