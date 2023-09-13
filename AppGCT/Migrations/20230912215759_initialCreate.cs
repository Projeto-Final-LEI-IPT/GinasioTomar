﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumSocio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NIF = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    EstadoUtilizador = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    RoleAux = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAprovacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimoLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeClasse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoClasse = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.IdClasse);
                });

            migrationBuilder.CreateTable(
                name: "Desconto",
                columns: table => new
                {
                    CodDesconto = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DescDesconto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoDesconto = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desconto", x => x.CodDesconto);
                });

            migrationBuilder.CreateTable(
                name: "Epoca",
                columns: table => new
                {
                    IdEpoca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEpoca = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoEpoca = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epoca", x => x.IdEpoca);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamento",
                columns: table => new
                {
                    CodMetodo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DescMetodo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    EstadoMetodo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamento", x => x.CodMetodo);
                });

            migrationBuilder.CreateTable(
                name: "Saldo",
                columns: table => new
                {
                    IdSocio = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    MSaldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldo", x => x.IdSocio);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ginasta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DtNascim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EstadoGinasta = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NumCC = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    NIF = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    NISS = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IBolsa = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IIrmaos = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NomeIrmaos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    NomeEE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NIFEE = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    prefixoTelemEE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    numTelemovelEE = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    IGrauEE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmailEE = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    NomeEmerEE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GrauEmerEE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PrefixoTlmEmerEE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    NumTlmEmerEE = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    EmailTlmEmerEE = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UtilizadorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ginasta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ginasta_AspNetUsers_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rubrica",
                columns: table => new
                {
                    CodRubrica = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DescricaoRubrica = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EstadoRubrica = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TipoMovimento = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IPrecario = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    OrdemPrecario = table.Column<int>(type: "int", nullable: true),
                    IVlrUnit = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IPagInscricao = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TipoRubrica = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    LocalTreino = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    HorasSemanais = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DescontoId = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    ClasseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubrica", x => x.CodRubrica);
                    table.ForeignKey(
                        name: "FK_Rubrica_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "IdClasse");
                    table.ForeignKey(
                        name: "FK_Rubrica_Desconto_DescontoId",
                        column: x => x.DescontoId,
                        principalTable: "Desconto",
                        principalColumn: "CodDesconto");
                });

            migrationBuilder.CreateTable(
                name: "Inscricao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFGP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ISocGinasta = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DtInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdadeAgosto = table.Column<int>(type: "int", nullable: true),
                    IConsentimento = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DtConsentimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IExamMed = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DtExamMed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IFicFGP = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DtFicFGP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISeguro = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IPagamInscricao = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ILeituraObrig = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IFotos = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IIbuprofeno = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IParacetamol = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IAntiInflam = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DescAlergias = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    GinastaId = table.Column<int>(type: "int", nullable: false),
                    EpocaId = table.Column<int>(type: "int", nullable: false),
                    ClasseId = table.Column<int>(type: "int", nullable: false),
                    CodDesconto = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscricao_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscricao_Desconto_CodDesconto",
                        column: x => x.CodDesconto,
                        principalTable: "Desconto",
                        principalColumn: "CodDesconto");
                    table.ForeignKey(
                        name: "FK_Inscricao_Epoca_EpocaId",
                        column: x => x.EpocaId,
                        principalTable: "Epoca",
                        principalColumn: "IdEpoca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscricao_Ginasta_GinastaId",
                        column: x => x.GinastaId,
                        principalTable: "Ginasta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoMensalidade",
                columns: table => new
                {
                    IdPlanoM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataMensalidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMensalidade = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ILancado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ValorMensalidadeLanc = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IdMovimento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    EpocaId = table.Column<int>(type: "int", nullable: false),
                    GinastaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoMensalidade", x => x.IdPlanoM);
                    table.ForeignKey(
                        name: "FK_PlanoMensalidade_Epoca_EpocaId",
                        column: x => x.EpocaId,
                        principalTable: "Epoca",
                        principalColumn: "IdEpoca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoMensalidade_Ginasta_GinastaId",
                        column: x => x.GinastaId,
                        principalTable: "Ginasta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesRubrica = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DtMovimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMovimento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    NumFatura = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumNotaCredito = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MSaldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UtilizadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AtletaMovimentoId = table.Column<int>(type: "int", nullable: true),
                    RubricaId = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    MetodoPagamentoId = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimento_AspNetUsers_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimento_Ginasta_AtletaMovimentoId",
                        column: x => x.AtletaMovimentoId,
                        principalTable: "Ginasta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimento_MetodoPagamento_MetodoPagamentoId",
                        column: x => x.MetodoPagamentoId,
                        principalTable: "MetodoPagamento",
                        principalColumn: "CodMetodo");
                    table.ForeignKey(
                        name: "FK_Movimento_Rubrica_RubricaId",
                        column: x => x.RubricaId,
                        principalTable: "Rubrica",
                        principalColumn: "CodRubrica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f1c2f57-905f-4edb-b7b9-63618654b45e", null, "Sócio", "SÓCIO" },
                    { "87090d3b-d29f-45ed-b220-cc81e3917973", null, "Ginásio", "GINÁSIO" },
                    { "c29fe571-98ac-4f1b-bac6-04f2cab5fc08", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleAux", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "15b79299-0851-4d69-91de-e7e6bdef2762", 0, "b6051f86-1259-47f8-ba7d-8ef43001314f", new DateTime(2023, 9, 12, 22, 57, 59, 360, DateTimeKind.Local).AddTicks(3619), new DateTime(2023, 9, 12, 22, 57, 59, 360, DateTimeKind.Local).AddTicks(3557), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 12, 22, 57, 59, 360, DateTimeKind.Local).AddTicks(3629), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEDhV2sbwY6LpoC14zaXLJ34tNbwXtEsqYlwOKihcPpk5Yw8m/Do38y9K3OF4WcAcIw==", "999999999", false, "Administrador", "4aa344f9-8cad-4f30-9915-6c0f5ad043e3", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "Classe",
                columns: new[] { "IdClasse", "DataCriacao", "DataModificacao", "EstadoClasse", "IdCriacao", "IdModificacao", "NomeClasse" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7483), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Aprendizagem 1" },
                    { 2, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7491), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Aprendizagem 2" },
                    { 3, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Aprendizagem 3" },
                    { 4, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7502), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Acrobática 1" },
                    { 5, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7518), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Acrobática 2" },
                    { 6, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7530), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Acrobática 3" },
                    { 7, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7535), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Trampolins 1" },
                    { 8, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7539), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Trampolins 2" },
                    { 9, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7544), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Ginástica para todos–Júnior" },
                    { 10, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7551), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Ginástica para todos–Universitários" }
                });

            migrationBuilder.InsertData(
                table: "Desconto",
                columns: new[] { "CodDesconto", "DataCriacao", "DataModificacao", "DescDesconto", "EstadoDesconto", "IdCriacao", "IdModificacao" },
                values: new object[,]
                {
                    { "00", new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7749), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolsa", "A", "SEED", " " },
                    { "01", new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parentesco(1º familiar)", "A", "SEED", " " },
                    { "02", new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7792), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parentesco(2º familiar)", "A", "SEED", " " },
                    { "03", new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7797), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parentesco(3º familiar)", "A", "SEED", " " }
                });

            migrationBuilder.InsertData(
                table: "Epoca",
                columns: new[] { "IdEpoca", "DataCriacao", "DataFim", "DataInicio", "DataModificacao", "EstadoEpoca", "IdCriacao", "IdModificacao", "NomeEpoca" },
                values: new object[] { 1, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7313), new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "2023/2024" });

            migrationBuilder.InsertData(
                table: "MetodoPagamento",
                columns: new[] { "CodMetodo", "DataCriacao", "DataModificacao", "DescMetodo", "EstadoMetodo", "IdCriacao", "IdModificacao", "ValorDesconto" },
                values: new object[,]
                {
                    { "00", new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7654), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Numerário", "A", "SEED", " ", 0m },
                    { "01", new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7665), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transferência Bancária", "A", "SEED", " ", 1m },
                    { "02", new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7671), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terminal Pagamento Automático(TPA)", "A", "SEED", " ", 0m }
                });

            migrationBuilder.InsertData(
                table: "Rubrica",
                columns: new[] { "CodRubrica", "ClasseId", "DataCriacao", "DataModificacao", "DescontoId", "DescricaoRubrica", "EstadoRubrica", "Horario", "HorasSemanais", "IPagInscricao", "IPrecario", "IVlrUnit", "IdCriacao", "IdModificacao", "LocalTreino", "OrdemPrecario", "TipoMovimento", "TipoRubrica", "ValorUnitario" },
                values: new object[,]
                {
                    { "001", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7858), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Inscrição", "A", "", "", "S", "S", "S", "SEED", " ", "", 1, "D", "G", 15m },
                    { "002", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Filiação FGP", "A", "", "", "S", "S", "S", "SEED", " ", "", 2, "D", "G", 10m },
                    { "003", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seguro", "A", "", "", "S", "S", "S", "SEED", " ", "", 3, "D", "G", 30m },
                    { "004", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7917), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quota Sócio", "A", "", "", "N", "S", "S", "SEED", " ", "", 4, "D", "S", 15m },
                    { "055", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8373), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pagamento", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "C", "P", 0m },
                    { "056", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8381), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Devolução", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "C", "D", 0m },
                    { "057", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8388), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regularização Débito", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "D", "R", 0m },
                    { "058", null, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8394), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regularização Crédito", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "C", "R", 0m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c29fe571-98ac-4f1b-bac6-04f2cab5fc08", "15b79299-0851-4d69-91de-e7e6bdef2762" });

            migrationBuilder.InsertData(
                table: "Rubrica",
                columns: new[] { "CodRubrica", "ClasseId", "DataCriacao", "DataModificacao", "DescontoId", "DescricaoRubrica", "EstadoRubrica", "Horario", "HorasSemanais", "IPagInscricao", "IPrecario", "IVlrUnit", "IdCriacao", "IdModificacao", "LocalTreino", "OrdemPrecario", "TipoMovimento", "TipoRubrica", "ValorUnitario" },
                values: new object[,]
                {
                    { "005", 1, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Aprendizagem 1", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 1, "D", "G", 27m },
                    { "006", 2, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Aprendizagem 2", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 2, "D", "G", 30m },
                    { "007", 3, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7943), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Aprendizagem 3", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 3, "D", "G", 32m },
                    { "008", 4, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7953), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Acrobática 1", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "S", "S", "SEED", " ", "Stª Iria", 4, "D", "G", 40m },
                    { "009", 5, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7960), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Acrobática 2", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "S", "S", "SEED", " ", "Stª Iria", 5, "D", "G", 45m },
                    { "010", 6, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7968), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Acrobática 3", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "S", "S", "SEED", " ", "Stª Iria", 6, "D", "G", 52m },
                    { "011", 7, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7975), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Trampolins 1", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 7, "D", "G", 36m },
                    { "012", 8, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(7988), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Trampolins 2", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 8, "D", "G", 45m },
                    { "013", 9, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8050), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. GPT – Júnior", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 9, "D", "G", 35m },
                    { "014", 10, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8057), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. GPT – Universitários", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 10, "D", "G", 18m },
                    { "015", 1, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8063), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. APZ 1 - Bolsa", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "016", 2, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8070), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. APZ 2 - Bolsa", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "017", 3, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8077), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. APZ 3 - Bolsa", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "018", 4, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8084), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. Acro 1 - Bolsa", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 0m },
                    { "019", 5, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8091), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. Acro 2 - Bolsa", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 0m },
                    { "020", 6, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8098), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. Acro 3 - Bolsa", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 0m },
                    { "021", 7, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8104), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. TRAMP 1 - Bolsa", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "022", 8, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8116), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. TRAMP 2 - Bolsa", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "023", 9, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8126), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. GPT – Júnior - Bolsa", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "024", 10, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8137), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. GPT – Univ. - Bolsa", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "025", 1, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8145), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. APZ 1 - Par.(1º)", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 24.3m },
                    { "026", 2, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8152), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. APZ 2 - Par.(1º)", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 27m },
                    { "027", 3, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8164), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. APZ 3 - Par.(1º)", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 28.8m },
                    { "028", 4, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. Acro 1 - Par.(1º)", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 36m },
                    { "029", 5, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8180), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. Acro 2 - Par.(1º)", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 40.5m },
                    { "030", 6, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8187), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. Acro 3 - Par.(1º)", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 46.8m },
                    { "031", 7, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8193), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. TRAMP 1 - Par.(1º)", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 32.4m },
                    { "032", 8, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8200), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. TRAMP 2 - Par.(1º)", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 40.5m },
                    { "033", 9, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. GPT – Júnior - Par.(1º)", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 31.5m },
                    { "034", 10, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8214), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. GPT – Univ. - Par.(1º)", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 16.2m },
                    { "035", 1, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8221), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. APZ 1 - Par.(2º)", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 22.95m },
                    { "036", 2, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8227), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. APZ 2 - Par.(2º)", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 25.5m },
                    { "037", 3, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8234), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. APZ 3 - Par.(2º)", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 27.2m },
                    { "038", 4, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8241), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. Acro 1 - Par.(2º)", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 34m },
                    { "039", 5, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8248), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. Acro 2 - Par.(2º)", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 38.25m },
                    { "040", 6, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8254), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. Acro 3 - Par.(2º)", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 44.2m },
                    { "041", 7, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8261), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. TRAMP 1 - Par.(2º)", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 30.6m },
                    { "042", 8, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8281), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. TRAMP 2 - Par.(2º)", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 38.25m },
                    { "043", 9, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8289), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. GPT – Júnior - Par.(2º)", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 29.75m },
                    { "044", 10, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8295), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. GPT – Univ. - Par.(2º)", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 15.3m },
                    { "045", 1, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8303), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. APZ 1 - Par.(3º)", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 21.6m },
                    { "046", 2, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8312), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. APZ 2 - Par.(3º)", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 24m },
                    { "047", 3, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8319), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. APZ 3 - Par.(3º)", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 25.6m },
                    { "048", 4, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8327), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. Acro 1 - Par.(3º)", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 32m },
                    { "049", 5, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8333), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. Acro 2 - Par.(3º)", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 36m },
                    { "050", 6, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. Acro 3 - Par.(3º)", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 41.6m },
                    { "051", 7, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8346), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. TRAMP 1 - Par.(3º)", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 28.8m },
                    { "052", 8, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8353), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. TRAMP 2 - Par.(3º)", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 36m },
                    { "053", 9, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. GPT – Júnior - Par.(3º)", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 28m },
                    { "054", 10, new DateTime(2023, 9, 12, 22, 57, 59, 503, DateTimeKind.Local).AddTicks(8367), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. GPT – Univ. - Par.(3º)", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 14.4m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ginasta_UtilizadorId",
                table: "Ginasta",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_ClasseId",
                table: "Inscricao",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_CodDesconto",
                table: "Inscricao",
                column: "CodDesconto");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_EpocaId",
                table: "Inscricao",
                column: "EpocaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_GinastaId",
                table: "Inscricao",
                column: "GinastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_AtletaMovimentoId",
                table: "Movimento",
                column: "AtletaMovimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_MetodoPagamentoId",
                table: "Movimento",
                column: "MetodoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_RubricaId",
                table: "Movimento",
                column: "RubricaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_UtilizadorId",
                table: "Movimento",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoMensalidade_EpocaId",
                table: "PlanoMensalidade",
                column: "EpocaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoMensalidade_GinastaId",
                table: "PlanoMensalidade",
                column: "GinastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rubrica_ClasseId",
                table: "Rubrica",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Rubrica_DescontoId",
                table: "Rubrica",
                column: "DescontoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Inscricao");

            migrationBuilder.DropTable(
                name: "Movimento");

            migrationBuilder.DropTable(
                name: "PlanoMensalidade");

            migrationBuilder.DropTable(
                name: "Saldo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MetodoPagamento");

            migrationBuilder.DropTable(
                name: "Rubrica");

            migrationBuilder.DropTable(
                name: "Epoca");

            migrationBuilder.DropTable(
                name: "Ginasta");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Desconto");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}