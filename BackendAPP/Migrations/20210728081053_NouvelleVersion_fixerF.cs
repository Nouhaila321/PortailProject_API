using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class NouvelleVersion_fixerF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom_Thamatique",
                table: "ClientThematique",
                newName: "Nom_Thematique");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom_Thematique",
                table: "ClientThematique",
                newName: "Nom_Thamatique");
        }
    }
}
