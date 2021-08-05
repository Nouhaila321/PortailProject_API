using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class NouvelleVersion_fixer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom_Client",
                table: "ClientThematique",
                newName: "Nom_Thamatique");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom_Thamatique",
                table: "ClientThematique",
                newName: "Nom_Client");
        }
    }
}
