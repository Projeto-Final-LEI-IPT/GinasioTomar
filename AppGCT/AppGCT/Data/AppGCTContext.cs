using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppGCT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AppGCT.Data
{
    public class AppGCTContext : IdentityDbContext<IdentityUser>
    {
        public AppGCTContext (DbContextOptions<AppGCTContext> options)
            : base(options)
        {
        }

        public DbSet<AppGCT.Models.Utilizador> Utilizador { get; set; } = default!;
    }
}
