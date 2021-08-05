using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class MigrationPart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientThematiques_clients_Id_Client",
                table: "clientThematiques");

            migrationBuilder.DropForeignKey(
                name: "FK_clientThematiques_thematiques_thematiqueId_thematique",
                table: "clientThematiques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_thematiques",
                table: "thematiques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_technologies",
                table: "technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientThematiques",
                table: "clientThematiques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clients",
                table: "clients");

            migrationBuilder.RenameTable(
                name: "thematiques",
                newName: "Thematiques");

            migrationBuilder.RenameTable(
                name: "technologies",
                newName: "Technologies");

            migrationBuilder.RenameTable(
                name: "clientThematiques",
                newName: "ClientThematiques");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "Clients");

            migrationBuilder.RenameColumn(
                name: "libelle",
                table: "Thematiques",
                newName: "Libelle");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Thematiques",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Id_thematique",
                table: "Thematiques",
                newName: "Id_Thematique");

            migrationBuilder.RenameColumn(
                name: "libelle",
                table: "Technologies",
                newName: "Libelle");

            migrationBuilder.RenameColumn(
                name: "Id_techno",
                table: "Technologies",
                newName: "Id_Techno");

            migrationBuilder.RenameColumn(
                name: "thematiqueId_thematique",
                table: "ClientThematiques",
                newName: "ThematiqueId_Thematique");

            migrationBuilder.RenameColumn(
                name: "Id_thematique",
                table: "ClientThematiques",
                newName: "Id_Thematique");

            migrationBuilder.RenameIndex(
                name: "IX_clientThematiques_thematiqueId_thematique",
                table: "ClientThematiques",
                newName: "IX_ClientThematiques_ThematiqueId_Thematique");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thematiques",
                table: "Thematiques",
                column: "Id_Thematique");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id_Techno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientThematiques",
                table: "ClientThematiques",
                columns: new[] { "Id_Client", "Id_Thematique" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id_Client");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientThematiques_Clients_Id_Client",
                table: "ClientThematiques",
                column: "Id_Client",
                principalTable: "Clients",
                principalColumn: "Id_Client",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientThematiques_Thematiques_ThematiqueId_Thematique",
                table: "ClientThematiques",
                column: "ThematiqueId_Thematique",
                principalTable: "Thematiques",
                principalColumn: "Id_Thematique",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientThematiques_Clients_Id_Client",
                table: "ClientThematiques");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientThematiques_Thematiques_ThematiqueId_Thematique",
                table: "ClientThematiques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thematiques",
                table: "Thematiques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientThematiques",
                table: "ClientThematiques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Thematiques",
                newName: "thematiques");

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "technologies");

            migrationBuilder.RenameTable(
                name: "ClientThematiques",
                newName: "clientThematiques");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "clients");

            migrationBuilder.RenameColumn(
                name: "Libelle",
                table: "thematiques",
                newName: "libelle");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "thematiques",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Id_Thematique",
                table: "thematiques",
                newName: "Id_thematique");

            migrationBuilder.RenameColumn(
                name: "Libelle",
                table: "technologies",
                newName: "libelle");

            migrationBuilder.RenameColumn(
                name: "Id_Techno",
                table: "technologies",
                newName: "Id_techno");

            migrationBuilder.RenameColumn(
                name: "ThematiqueId_Thematique",
                table: "clientThematiques",
                newName: "thematiqueId_thematique");

            migrationBuilder.RenameColumn(
                name: "Id_Thematique",
                table: "clientThematiques",
                newName: "Id_thematique");

            migrationBuilder.RenameIndex(
                name: "IX_ClientThematiques_ThematiqueId_Thematique",
                table: "clientThematiques",
                newName: "IX_clientThematiques_thematiqueId_thematique");

            migrationBuilder.AddPrimaryKey(
                name: "PK_thematiques",
                table: "thematiques",
                column: "Id_thematique");

            migrationBuilder.AddPrimaryKey(
                name: "PK_technologies",
                table: "technologies",
                column: "Id_techno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientThematiques",
                table: "clientThematiques",
                columns: new[] { "Id_Client", "Id_thematique" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_clients",
                table: "clients",
                column: "Id_Client");

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
    }
}
