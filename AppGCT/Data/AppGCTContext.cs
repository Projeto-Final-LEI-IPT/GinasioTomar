using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppGCT.Models;

namespace AppGCT.Data
{
    public class AppGCTContext : DbContext
    {
        public AppGCTContext (DbContextOptions<AppGCTContext> options)
            : base(options)
        {
        }

        public DbSet<AppGCT.Models.Utilizadores> Utilizadores { get; set; } = default!;
    }
}
