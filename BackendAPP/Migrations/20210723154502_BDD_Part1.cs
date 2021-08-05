using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class BDD_Part1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_Poles",
                table: "Poles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientThematiques",
                table: "ClientThematiques");

            migrationBuilder.DropIndex(
                name: "IX_ClientThematiques_ThematiqueId_Thematique",
                table: "ClientThematiques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ThematiqueId_Thematique",
                table: "ClientThematiques");

            migrationBuilder.RenameTable(
                name: "Thematiques",
                newName: "Thematique");

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "Technologie");

            migrationBuilder.RenameTable(
                name: "Poles",
                newName: "Pole");

            migrationBuilder.RenameTable(
                name: "ClientThematiques",
                newName: "ClientThematique");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thematique",
                table: "Thematique",
                column: "Id_Thematique");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologie",
                table: "Technologie",
                column: "Id_Techno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pole",
                table: "Pole",
                column: "Id_Pole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientThematique",
                table: "ClientThematique",
                columns: new[] { "Id_Client", "Id_Thematique" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id_Client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Thematique",
                table: "Thematique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologie",
                table: "Technologie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pole",
                table: "Pole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientThematique",
                table: "ClientThematique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Thematique",
                newName: "Thematiques");

            migrationBuilder.RenameTable(
                name: "Technologie",
                newName: "Technologies");

            migrationBuilder.RenameTable(
                name: "Pole",
                newName: "Poles");

            migrationBuilder.RenameTable(
                name: "ClientThematique",
                newName: "ClientThematiques");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.AddColumn<long>(
                name: "ThematiqueId_Thematique",
                table: "ClientThematiques",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thematiques",
                table: "Thematiques",
                column: "Id_Thematique");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id_Techno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poles",
                table: "Poles",
                column: "Id_Pole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientThematiques",
                table: "ClientThematiques",
                columns: new[] { "Id_Client", "Id_Thematique" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id_Client");

            migrationBuilder.CreateIndex(
                name: "IX_ClientThematiques_ThematiqueId_Thematique",
                table: "ClientThematiques",
                column: "ThematiqueId_Thematique");

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
    }
}
