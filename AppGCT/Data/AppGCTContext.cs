using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AppGCT.Models;

namespace AppGCT.Data
{
    public class AppGCTContext : IdentityDbContext<Utilizador>
    {
        public AppGCTContext (DbContextOptions<AppGCTContext> options)
            : base(options)
        {
        }
        public DbSet<AppGCT.Models.Epoca> Epoca { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
