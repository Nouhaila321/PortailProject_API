using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class NouvelleVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageGalerie");

            migrationBuilder.DropTable(
                name: "Technologie");

            migrationBuilder.DropTable(
                name: "Thematique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjetTechnologie",
                table: "ProjetTechnologie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projet",
                table: "Projet");

            migrationBuilder.RenameColumn(
                name: "Id_Technologie",
                table: "ProjetTechnologie",
                newName: "id_technologie");

            migrationBuilder.RenameColumn(
                name: "Id_Projet",
                table: "ProjetTechnologie",
                newName: "id_projet");

            migrationBuilder.RenameColumn(
                name: "Presentation",
                table: "Client",
                newName: "Description");

            migrationBuilder.AddColumn<long>(
                name: "id_client",
                table: "ProjetTechnologie",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "chemin_technologie",
                table: "ProjetTechnologie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nom_technologie",
                table: "ProjetTechnologie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Projet",
                table: "Projet",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<long>(
                name: "Id_Thematique",
                table: "ClientThematique",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Nom_Client",
                table: "ClientThematique",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjetTechnologie",
                table: "ProjetTechnologie",
                columns: new[] { "id_projet", "id_client", "id_technologie" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projet",
                table: "Projet",
                columns: new[] { "Id_Projet", "Id_Client" });

            migrationBuilder.CreateTable(
                name: "ProjetGalerie",
                columns: table => new
                {
                    Id_Image = table.Column<long>(type: "INTEGER", nullable: false),
                    id_client = table.Column<long>(type: "INTEGER", nullable: false),
                    Id_Projet = table.Column<int>(type: "INTEGER", nullable: false),
                    titre = table.Column<string>(type: "TEXT", nullable: true),
                    Chemin = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetGalerie", x => new { x.id_client, x.Id_Projet, x.Id_Image });
                });

            migrationBuilder.CreateTable(
                name: "ProjetThematique",
                columns: table => new
                {
                    id_thematique = table.Column<long>(type: "INTEGER", nullable: false),
                    id_projet = table.Column<long>(type: "INTEGER", nullable: false),
                    id_client = table.Column<long>(type: "INTEGER", nullable: false),
                    nom_thematique = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetThematique", x => new { x.id_client, x.id_projet, x.id_thematique });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetGalerie");

            migrationBuilder.DropTable(
                name: "ProjetThematique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjetTechnologie",
                table: "ProjetTechnologie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projet",
                table: "Projet");

            migrationBuilder.DropColumn(
                name: "id_client",
                table: "ProjetTechnologie");

            migrationBuilder.DropColumn(
                name: "chemin_technologie",
                table: "ProjetTechnologie");

            migrationBuilder.DropColumn(
                name: "nom_technologie",
                table: "ProjetTechnologie");

            migrationBuilder.DropColumn(
                name: "Nom_Client",
                table: "ClientThematique");

            migrationBuilder.RenameColumn(
                name: "id_technologie",
                table: "ProjetTechnologie",
                newName: "Id_Technologie");

            migrationBuilder.RenameColumn(
                name: "id_projet",
                table: "ProjetTechnologie",
                newName: "Id_Projet");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Client",
                newName: "Presentation");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Projet",
                table: "Projet",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Thematique",
                table: "ClientThematique",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjetTechnologie",
                table: "ProjetTechnologie",
                columns: new[] { "Id_Projet", "Id_Technologie" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projet",
                table: "Projet",
                column: "Id_Projet");

            migrationBuilder.CreateTable(
                name: "ImageGalerie",
                columns: table => new
                {
                    Id_Image = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Chemin = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Id_Projet = table.Column<int>(type: "INTEGER", nullable: false),
                    Ordre = table.Column<int>(type: "INTEGER", nullable: false),
                    Titre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGalerie", x => x.Id_Image);
                });

            migrationBuilder.CreateTable(
                name: "Technologie",
                columns: table => new
                {
                    Id_Techno = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologie", x => x.Id_Techno);
                });

            migrationBuilder.CreateTable(
                name: "Thematique",
                columns: table => new
                {
                    Id_Thematique = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thematique", x => x.Id_Thematique);
                });
        }
    }
}
