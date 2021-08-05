using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class BDD_Part2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborateur",
                columns: table => new
                {
                    Id_Collaborateur = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Photo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateur", x => x.Id_Collaborateur);
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurActivite",
                columns: table => new
                {
                    Id_Collaborateur = table.Column<string>(type: "TEXT", nullable: false),
                    Id_Projet = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurActivite", x => new { x.Id_Projet, x.Id_Collaborateur });
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurTechnologie",
                columns: table => new
                {
                    Id_Collaborateur = table.Column<string>(type: "TEXT", nullable: false),
                    Id_Technologie = table.Column<long>(type: "INTEGER", nullable: false),
                    Niveau = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurTechnologie", x => new { x.Id_Collaborateur, x.Id_Technologie });
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurThematique",
                columns: table => new
                {
                    Id_Collaborateur = table.Column<string>(type: "TEXT", nullable: false),
                    Id_Thematique = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurThematique", x => new { x.Id_Thematique, x.Id_Collaborateur });
                });

            migrationBuilder.CreateTable(
                name: "ImageGalerie",
                columns: table => new
                {
                    Id_Image = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Chemin = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Titre = table.Column<string>(type: "TEXT", nullable: true),
                    Ordre = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Projet = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGalerie", x => x.Id_Image);
                });

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    Id_Projet = table.Column<string>(type: "TEXT", nullable: false),
                    Libelle = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    EM = table.Column<string>(type: "TEXT", nullable: true),
                    Domaine = table.Column<string>(type: "TEXT", nullable: true),
                    Statut = table.Column<string>(type: "TEXT", nullable: true),
                    Id_Pole = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Client = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.Id_Projet);
                });

            migrationBuilder.CreateTable(
                name: "ProjetTechnologie",
                columns: table => new
                {
                    Id_Projet = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Technologie = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetTechnologie", x => new { x.Id_Projet, x.Id_Technologie });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborateur");

            migrationBuilder.DropTable(
                name: "CollaborateurActivite");

            migrationBuilder.DropTable(
                name: "CollaborateurTechnologie");

            migrationBuilder.DropTable(
                name: "CollaborateurThematique");

            migrationBuilder.DropTable(
                name: "ImageGalerie");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropTable(
                name: "ProjetTechnologie");
        }
    }
}
