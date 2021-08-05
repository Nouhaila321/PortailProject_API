using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class MigrationForKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "thematiqueId_thematique",
                table: "clientThematiques",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientThematiques_thematiqueId_thematique",
                table: "clientThematiques",
                column: "thematiqueId_thematique");

            migrationBuilder.AddForeignKey(
                name: "FK_clientThematiques_clients_Id_Client",
                table: "clientThematiques",
                column: "Id_Client",
                principalTable: "clients",
                principalColumn: "Id_Client",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clientThematiques_thematiques_thematiqueId_thematique",
                table: "clientThematiques",
                column: "thematiqueId_thematique",
                principalTable: "thematiques",
                principalColumn: "Id_thematique",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientThematiques_clients_Id_Client",
                table: "clientThematiques");

            migrationBuilder.DropForeignKey(
                name: "FK_clientThematiques_thematiques_thematiqueId_thematique",
                table: "clientThematiques");

            migrationBuilder.DropIndex(
                name: "IX_clientThematiques_thematiqueId_thematique",
                table: "clientThematiques");

            migrationBuilder.DropColumn(
                name: "thematiqueId_thematique",
                table: "clientThematiques");
        }
    }
}
