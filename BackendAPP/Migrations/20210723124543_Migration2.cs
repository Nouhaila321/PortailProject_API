using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id_Client = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom_Client = table.Column<string>(type: "TEXT", nullable: true),
                    Presentation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id_Client);
                });

            migrationBuilder.CreateTable(
                name: "clientThematiques",
                columns: table => new
                {
                    Id_Client = table.Column<long>(type: "INTEGER", nullable: false),
                    Id_thematique = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientThematiques", x => new { x.Id_Client, x.Id_thematique });
                });

            migrationBuilder.CreateTable(
                name: "Poles",
                columns: table => new
                {
                    Id_Pole = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom_Pole = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poles", x => x.Id_Pole);
                });

            migrationBuilder.CreateTable(
                name: "thematiques",
                columns: table => new
                {
                    Id_thematique = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    libelle = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thematiques", x => x.Id_thematique);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "clientThematiques");

            migrationBuilder.DropTable(
                name: "Poles");

            migrationBuilder.DropTable(
                name: "thematiques");
        }
    }
}
