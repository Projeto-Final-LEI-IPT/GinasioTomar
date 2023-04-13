﻿// <auto-generated />
using System;
using AppGCT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppGCT.Migrations
{
    [DbContext(typeof(AppGCTContext))]
    partial class AppGCTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppGCT.Areas.Identity.Data.Utilizador", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAprovacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascim")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EstadoUtilizador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCriacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdModificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NumSocio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UltimoLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b5ee057f-3821-481c-924f-6e0a5d6c18ac",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3f3860d6-0a7c-40fe-9013-4243efdb8c71",
                            DataAprovacao = new DateTime(2023, 4, 13, 15, 49, 30, 233, DateTimeKind.Local).AddTicks(4006),
                            DataCriacao = new DateTime(2023, 4, 13, 15, 49, 30, 233, DateTimeKind.Local).AddTicks(3954),
                            DataModificacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascim = new DateTime(2023, 4, 13, 15, 49, 30, 233, DateTimeKind.Local).AddTicks(4010),
                            Email = "admin@localhost",
                            EmailConfirmed = true,
                            EstadoUtilizador = "A",
                            IdCriacao = "SEED",
                            IdModificacao = " ",
                            LockoutEnabled = false,
                            Morada = "Ginásio Clube de Tomar",
                            NIF = "999999999",
                            Nome = "Administrador",
                            NormalizedEmail = "ADMIN@LOCALHOST",
                            NormalizedUserName = "ADMIN@LOCALHOST",
                            NumSocio = " ",
                            PasswordHash = "AQAAAAIAAYagAAAAELXcM9+4Se9szE2OZLjbeGY7FphT00unZ0agq3OHKyKCGseo9QdqbHrkFlhAHfCjcA==",
                            PhoneNumber = "999999999",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5c4bfa10-e406-4e2c-8ff1-a4b203889c7f",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost"
                        });
                });

            modelBuilder.Entity("AppGCT.Models.Desconto", b =>
                {
                    b.Property<string>("CodDesconto")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescDesconto")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EstadoDesconto")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("IdCriacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdModificacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodDesconto");

                    b.ToTable("Desconto");
                });

            modelBuilder.Entity("AppGCT.Models.Epoca", b =>
                {
                    b.Property<int>("IdEpoca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEpoca"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoEpoca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCriacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdModificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEpoca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEpoca");

                    b.ToTable("Epoca");
                });

            modelBuilder.Entity("AppGCT.Models.Ginasta", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("CodPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtNascim")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailEE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailTlmEmerEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoGinasta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrauEmerEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBolsa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IGrauEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IIrmaos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCriacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdModificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdadeAgosto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIFEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NISS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEmerEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeIrmaos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumCC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTlmEmerEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefixoTlmEmerEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UtilizadorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("numTelemovelEE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prefixoTelemEE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Ginasta");
                });

            modelBuilder.Entity("AppGCT.Models.Inscricao", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("GinastaId")
                        .HasColumnType("int");

                    b.Property<string>("ISocGinasta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdFGP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GinastaId");

                    b.ToTable("Inscricao");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a3c57eaa-2938-4f35-b791-eb68db0e7ee7",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "71000b1d-5e61-44d0-8759-dd6a64a64d7b",
                            Name = "Ginásio",
                            NormalizedName = "GINÁSIO"
                        },
                        new
                        {
                            Id = "69d6ac14-3154-4365-a2e1-683e725c3f46",
                            Name = "Sócio",
                            NormalizedName = "SÓCIO"
                        },
                        new
                        {
                            Id = "28a6b357-6d89-4e14-aab9-727af9744fde",
                            Name = "Anónimo",
                            NormalizedName = "ANÓNIMO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "b5ee057f-3821-481c-924f-6e0a5d6c18ac",
                            RoleId = "a3c57eaa-2938-4f35-b791-eb68db0e7ee7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AppGCT.Models.Ginasta", b =>
                {
                    b.HasOne("AppGCT.Areas.Identity.Data.Utilizador", "Socio")
                        .WithMany("Ginasta")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("AppGCT.Models.Inscricao", b =>
                {
                    b.HasOne("AppGCT.Models.Ginasta", "Atleta")
                        .WithMany("inscricao")
                        .HasForeignKey("GinastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atleta");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AppGCT.Areas.Identity.Data.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AppGCT.Areas.Identity.Data.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppGCT.Areas.Identity.Data.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AppGCT.Areas.Identity.Data.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppGCT.Areas.Identity.Data.Utilizador", b =>
                {
                    b.Navigation("Ginasta");
                });

            modelBuilder.Entity("AppGCT.Models.Ginasta", b =>
                {
                    b.Navigation("inscricao");
                });
#pragma warning restore 612, 618
        }
    }
}
