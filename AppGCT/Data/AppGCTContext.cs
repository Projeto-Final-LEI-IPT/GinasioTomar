using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AppGCT.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace AppGCT.Data
{
    public class AppGCTContext : IdentityDbContext<Utilizador>
    {
        public AppGCTContext (DbContextOptions<AppGCTContext> options)
            : base(options)
        {
        }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<AppGCT.Models.Epoca> Epoca { get; set; } = default!;



        public DbSet<AppGCT.Models.Desconto> Desconto { get; set; } = default!;

        public DbSet<AppGCT.Models.Ginasta> Ginasta { get; set; } = default!;

        public DbSet<AppGCT.Models.Inscricao> Inscricao { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var configuration = new ConfigurationBuilder()
                                    .AddUserSecrets<Program>()
                                    .Build();

            builder.Seed(configuration);

            builder.Entity<Ginasta>()
                   .HasOne(p => p.Socio)
                   .WithMany(a => a.Ginasta)
                   .HasForeignKey(p => p.UtilizadorId);

            builder.Entity<Inscricao>()
                   .HasOne(p => p.Atleta)
                   .WithMany(a => a.Inscricoes)
                   .HasForeignKey(p => p.GinastaId);

            builder.Entity<Inscricao>()
                   .HasOne(p => p.Periodo)
                   .WithMany(a => a.Inscricoes)
                   .HasForeignKey(p => p.EpocaId);

            builder.Entity<Inscricao>()
                  .HasOne(p => p.Class)
                  .WithMany(a => a.Inscricoes)
                  .HasForeignKey(p => p.ClasseId);

            builder.Entity<Inscricao>()
                  .HasOne(p => p.Descont)
                  .WithMany(a => a.Inscricoes)
                  .HasForeignKey(p => p.CodDesconto)
                  .IsRequired(false);

            builder.Entity<Rubrica>()
                   .HasOne(p => p.Discount)
                   .WithMany(p => p.Rubricas)
                   .HasForeignKey(p => p.DescontoId)
                   .IsRequired(false);

            builder.Entity<Rubrica>()
                   .HasOne(p => p.Modalidade)
                   .WithMany(p => p.Rubricas)
                   .HasForeignKey(p => p.ClasseId)
                   .IsRequired(false);

            builder.Entity<Movimento>()
                   .HasOne(p => p.Socio)
                   .WithMany(a => a.Movimentos)
                   .HasForeignKey(p => p.UtilizadorId);

            builder.Entity<Movimento>()
                  .HasOne(p => p.Atleta)
                  .WithMany(a => a.Movimentos)
                  .HasForeignKey(p => p.AtletaMovimentoId)
                  .IsRequired(false);

            builder.Entity<Movimento>()
                   .HasOne(p => p.TipoDespesa)
                   .WithMany(p => p.Movimentos)
                   .HasForeignKey(p => p.RubricaId);

            builder.Entity<Movimento>()
                   .HasOne(p => p.FormaPagamento)
                   .WithMany(p => p.Movimentos)
                   .HasForeignKey(p => p.MetodoPagamentoId);

            builder.Entity<PlanoMensalidade>()
                   .HasOne(p => p.Epoca)
                   .WithMany(a => a.Planos)
                   .HasForeignKey(p => p.EpocaId);

            builder.Entity<PlanoMensalidade>()
                   .HasOne(p => p.Aluno)
                   .WithMany(a => a.Planos)
                   .HasForeignKey(p => p.GinastaId);
        }

        public DbSet<AppGCT.Models.Classe> Classe { get; set; } = default!;

        public DbSet<AppGCT.Models.MetodoPagamento> MetodoPagamento { get; set; } = default!;

        public DbSet<AppGCT.Models.Rubrica> Rubrica { get; set; } = default!;

        public DbSet<AppGCT.Models.Movimento> Movimento { get; set; } = default!;
        public DbSet<AppGCT.Models.PlanoMensalidade> PlanoMensalidade { get; set; } = default!;

        public DbSet<AppGCT.Models.Saldo> Saldo { get; set; } = default!;
    }
}
