using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppGCT.Models;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppGCT.Data
{
    public class AppGCTContext : IdentityDbContext<AppGCTUser>
    {
        public AppGCTContext (DbContextOptions<AppGCTContext> options)
            : base(options)
        {
        }

        public DbSet<AppGCT.Models.Utilizadores> Utilizadores { get; set; } = default!;
    }
}
