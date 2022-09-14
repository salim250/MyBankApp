using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace JwtAuthDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "text", nullable: true),
                    prenom = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Virements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    compteDebiteur = table.Column<int>(type: "int", nullable: false),
                    compteACrediter = table.Column<int>(type: "int", nullable: false),
                    montant = table.Column<int>(type: "int", nullable: false),
                    motif = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Virements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NumeroCompte = table.Column<int>(type: "int", nullable: false),
                    cin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandeCartes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    dateDemande = table.Column<DateTime>(type: "datetime", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    etat = table.Column<string>(type: "text", nullable: true),
                    clientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeCartes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeCartes_Client_clientId",
                        column: x => x.clientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DemandeChequiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    dateDemande = table.Column<DateTime>(type: "datetime", nullable: false),
                    nombre = table.Column<int>(type: "int", nullable: false),
                    etat = table.Column<string>(type: "text", nullable: true),
                    clientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeChequiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeChequiers_Client_clientId",
                        column: x => x.clientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Soldes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    operation = table.Column<string>(type: "text", nullable: true),
                    montantRetire = table.Column<int>(type: "int", nullable: false),
                    montantVerse = table.Column<int>(type: "int", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soldes_Client_clientId",
                        column: x => x.clientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transferts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    montant = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    clientDebiteurId = table.Column<int>(type: "int", nullable: true),
                    clientRecepteurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferts_Client_clientDebiteurId",
                        column: x => x.clientDebiteurId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferts_Client_clientRecepteurId",
                        column: x => x.clientRecepteurId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandeCartes_clientId",
                table: "DemandeCartes",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeChequiers_clientId",
                table: "DemandeChequiers",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldes_clientId",
                table: "Soldes",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_clientDebiteurId",
                table: "Transferts",
                column: "clientDebiteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_clientRecepteurId",
                table: "Transferts",
                column: "clientRecepteurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandeCartes");

            migrationBuilder.DropTable(
                name: "DemandeChequiers");

            migrationBuilder.DropTable(
                name: "Soldes");

            migrationBuilder.DropTable(
                name: "Transferts");

            migrationBuilder.DropTable(
                name: "Virements");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
