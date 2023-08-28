using System;
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
                    IdMovimento = table.Column<int>(type: "int", nullable: true),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    { "aa6293fb-2836-479c-95b2-003bc6200fbd", null, "Administrador", "ADMINISTRADOR" },
                    { "c684505a-6f7d-4f59-8a5f-844f57ccefa6", null, "Sócio", "SÓCIO" },
                    { "f97c5eb7-d093-440d-8b34-14232ca22229", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleAux", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "b778e264-102e-4125-bc05-ee3ea3944afb", 0, "117e551c-a726-4699-bea4-dbec552ec8bc", new DateTime(2023, 8, 27, 22, 46, 13, 435, DateTimeKind.Local).AddTicks(5808), new DateTime(2023, 8, 27, 22, 46, 13, 435, DateTimeKind.Local).AddTicks(5755), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 27, 22, 46, 13, 435, DateTimeKind.Local).AddTicks(5813), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEMtibhP9O9h8RrHWtVyw7VapsnuVll1MCnzOW1RD54oNtwQcgZnLeEbz4B4i4oZrjQ==", "999999999", false, "Administrador", "b94987d9-2be6-41d8-8486-2ab09657c1e3", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "Classe",
                columns: new[] { "IdClasse", "DataCriacao", "DataModificacao", "EstadoClasse", "IdCriacao", "IdModificacao", "NomeClasse" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(4954), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Aprendizagem 1" },
                    { 2, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(4963), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Aprendizagem 2" },
                    { 3, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(4968), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Aprendizagem 3" },
                    { 4, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(4972), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Acrobática 1" },
                    { 5, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(4984), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Acrobática 2" },
                    { 6, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5002), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Acrobática 3" },
                    { 7, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Trampolins 1" },
                    { 8, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5010), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Trampolins 2" },
                    { 9, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Ginástica para todos–Júnior" },
                    { 10, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "Ginástica para todos–Universitários" }
                });

            migrationBuilder.InsertData(
                table: "Desconto",
                columns: new[] { "CodDesconto", "DataCriacao", "DataModificacao", "DescDesconto", "EstadoDesconto", "IdCriacao", "IdModificacao" },
                values: new object[,]
                {
                    { "00", new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolsa", "A", "SEED", " " },
                    { "01", new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parentesco(1º familiar)", "A", "SEED", " " },
                    { "02", new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5304), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parentesco(2º familiar)", "A", "SEED", " " },
                    { "03", new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5310), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parentesco(3º familiar)", "A", "SEED", " " }
                });

            migrationBuilder.InsertData(
                table: "Epoca",
                columns: new[] { "IdEpoca", "DataCriacao", "DataFim", "DataInicio", "DataModificacao", "EstadoEpoca", "IdCriacao", "IdModificacao", "NomeEpoca" },
                values: new object[] { 1, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(4790), new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", "SEED", " ", "2023/2024" });

            migrationBuilder.InsertData(
                table: "MetodoPagamento",
                columns: new[] { "CodMetodo", "DataCriacao", "DataModificacao", "DescMetodo", "EstadoMetodo", "IdCriacao", "IdModificacao", "ValorDesconto" },
                values: new object[,]
                {
                    { "00", new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5133), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Numerário", "A", "SEED", " ", 0m },
                    { "01", new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5143), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transferência Bancária", "A", "SEED", " ", 1m },
                    { "02", new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5147), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terminal Pagamento Automático(TPA)", "A", "SEED", " ", 0m }
                });

            migrationBuilder.InsertData(
                table: "Rubrica",
                columns: new[] { "CodRubrica", "ClasseId", "DataCriacao", "DataModificacao", "DescontoId", "DescricaoRubrica", "EstadoRubrica", "Horario", "HorasSemanais", "IPagInscricao", "IPrecario", "IVlrUnit", "IdCriacao", "IdModificacao", "LocalTreino", "OrdemPrecario", "TipoMovimento", "TipoRubrica", "ValorUnitario" },
                values: new object[,]
                {
                    { "001", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Inscrição", "A", "", "", "S", "S", "S", "SEED", " ", "", 1, "D", "G", 15m },
                    { "002", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5402), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Filiação FGP", "A", "", "", "S", "S", "S", "SEED", " ", "", 2, "D", "G", 10m },
                    { "003", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5408), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seguro", "A", "", "", "S", "S", "S", "SEED", " ", "", 3, "D", "G", 30m },
                    { "004", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5414), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quota Sócio", "A", "", "", "N", "S", "S", "SEED", " ", "", 4, "D", "S", 15m },
                    { "055", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5831), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pagamento", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "C", "P", 0m },
                    { "056", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5837), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Devolução", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "C", "D", 0m },
                    { "057", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5842), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regularização Débito", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "D", "R", 0m },
                    { "058", null, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regularização Crédito", "A", "", "", "N", "N", "N", "SEED", " ", "", null, "C", "R", 0m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aa6293fb-2836-479c-95b2-003bc6200fbd", "b778e264-102e-4125-bc05-ee3ea3944afb" });

            migrationBuilder.InsertData(
                table: "Rubrica",
                columns: new[] { "CodRubrica", "ClasseId", "DataCriacao", "DataModificacao", "DescontoId", "DescricaoRubrica", "EstadoRubrica", "Horario", "HorasSemanais", "IPagInscricao", "IPrecario", "IVlrUnit", "IdCriacao", "IdModificacao", "LocalTreino", "OrdemPrecario", "TipoMovimento", "TipoRubrica", "ValorUnitario" },
                values: new object[,]
                {
                    { "005", 1, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5420), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Aprendizagem 1", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 1, "D", "G", 27m },
                    { "006", 2, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5426), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Aprendizagem 2", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 2, "D", "G", 30m },
                    { "007", 3, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5438), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Aprendizagem 3", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 3, "D", "G", 32m },
                    { "008", 4, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5444), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Acrobática 1", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "S", "S", "SEED", " ", "Stª Iria", 4, "D", "G", 40m },
                    { "009", 5, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Acrobática 2", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "S", "S", "SEED", " ", "Stª Iria", 5, "D", "G", 45m },
                    { "010", 6, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5458), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Acrobática 3", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "S", "S", "SEED", " ", "Stª Iria", 6, "D", "G", 52m },
                    { "011", 7, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5465), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Trampolins 1", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 7, "D", "G", 36m },
                    { "012", 8, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5479), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. Trampolins 2", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 8, "D", "G", 45m },
                    { "013", 9, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5548), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. GPT – Júnior", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 9, "D", "G", 35m },
                    { "014", 10, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5555), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mens. GPT – Universitários", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "S", "S", "SEED", " ", "Gualdim Pais", 10, "D", "G", 18m },
                    { "015", 1, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5560), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. APZ 1 - Bolsa", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "016", 2, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5569), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. APZ 2 - Bolsa", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "017", 3, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5575), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. APZ 3 - Bolsa", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "018", 4, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5580), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. Acro 1 - Bolsa", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 0m },
                    { "019", 5, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5586), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. Acro 2 - Bolsa", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 0m },
                    { "020", 6, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. Acro 3 - Bolsa", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 0m },
                    { "021", 7, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5599), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. TRAMP 1 - Bolsa", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "022", 8, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5605), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. TRAMP 2 - Bolsa", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "023", 9, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5611), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. GPT – Júnior - Bolsa", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "024", 10, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5617), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00", "Mens. GPT – Univ. - Bolsa", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 0m },
                    { "025", 1, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5625), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. APZ 1 - Par.(1º)", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 24.3m },
                    { "026", 2, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. APZ 2 - Par.(1º)", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 27m },
                    { "027", 3, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5648), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. APZ 3 - Par.(1º)", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 28.8m },
                    { "028", 4, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5653), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. Acro 1 - Par.(1º)", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 36m },
                    { "029", 5, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5659), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. Acro 2 - Par.(1º)", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 40.5m },
                    { "030", 6, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5665), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. Acro 3 - Par.(1º)", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 46.8m },
                    { "031", 7, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. TRAMP 1 - Par.(1º)", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 32.4m },
                    { "032", 8, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5678), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. TRAMP 2 - Par.(1º)", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 40.5m },
                    { "033", 9, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5684), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. GPT – Júnior - Par.(1º)", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 31.5m },
                    { "034", 10, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01", "Mens. GPT – Univ. - Par.(1º)", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 16.2m },
                    { "035", 1, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5695), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. APZ 1 - Par.(2º)", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 22.95m },
                    { "036", 2, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. APZ 2 - Par.(2º)", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 25.5m },
                    { "037", 3, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5706), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. APZ 3 - Par.(2º)", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 27.2m },
                    { "038", 4, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5712), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. Acro 1 - Par.(2º)", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 34m },
                    { "039", 5, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5718), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. Acro 2 - Par.(2º)", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 38.25m },
                    { "040", 6, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5723), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. Acro 3 - Par.(2º)", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 44.2m },
                    { "041", 7, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5730), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. TRAMP 1 - Par.(2º)", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 30.6m },
                    { "042", 8, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5736), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. TRAMP 2 - Par.(2º)", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 38.25m },
                    { "043", 9, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5741), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. GPT – Júnior - Par.(2º)", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 29.75m },
                    { "044", 10, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5747), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02", "Mens. GPT – Univ. - Par.(2º)", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 15.3m },
                    { "045", 1, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5757), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. APZ 1 - Par.(3º)", "A", "2ª e 5ª 17h45 às 18h30 (2x semana)", "1h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 21.6m },
                    { "046", 2, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5765), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. APZ 2 - Par.(3º)", "A", "2ª e 5ª 18h15 às 19h30  (2x semana)", "2h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 24m },
                    { "047", 3, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5771), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. APZ 3 - Par.(3º)", "A", "3ª e 6ª 17h45 às 19h15  (2x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 25.6m },
                    { "048", 4, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5776), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. Acro 1 - Par.(3º)", "A", "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)", "7h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 32m },
                    { "049", 5, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5782), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. Acro 2 - Par.(3º)", "A", "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)", "9h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 36m },
                    { "050", 6, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5788), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. Acro 3 - Par.(3º)", "A", "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)", "12h00m", "N", "N", "S", "SEED", " ", "Stª Iria", null, "D", "G", 41.6m },
                    { "051", 7, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5806), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. TRAMP 1 - Par.(3º)", "A", "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)", "5h30m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 28.8m },
                    { "052", 8, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5812), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. TRAMP 2 - Par.(3º)", "A", "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)", "9h15m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 36m },
                    { "053", 9, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. GPT – Júnior - Par.(3º)", "A", "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)", "5h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 28m },
                    { "054", 10, new DateTime(2023, 8, 27, 22, 46, 13, 544, DateTimeKind.Local).AddTicks(5823), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03", "Mens. GPT – Univ. - Par.(3º)", "A", "Sábado 10h00 às 13h00 (1x semana)", "3h00m", "N", "N", "S", "SEED", " ", "Gualdim Pais", null, "D", "G", 14.4m }
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
