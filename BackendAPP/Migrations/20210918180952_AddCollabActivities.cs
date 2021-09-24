using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class AddCollabActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjetThematique",
                table: "ProjetThematique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjetGalerie",
                table: "ProjetGalerie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projet",
                table: "Projet");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CollaborateurActivite");

            migrationBuilder.AlterColumn<long>(
                name: "Id_Projet",
                table: "Projet",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<double>(
                name: "Days",
                table: "CollaborateurActivite",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjetThematique",
                table: "ProjetThematique",
                columns: new[] { "id_projet", "id_client", "id_thematique" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjetGalerie",
                table: "ProjetGalerie",
                columns: new[] { "Id_Projet", "id_client", "Id_Image" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projet",
                table: "Projet",
                column: "Id_Projet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjetThematique",
                table: "ProjetThematique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjetGalerie",
                table: "ProjetGalerie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projet",
                table: "Projet");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "CollaborateurActivite");

            migrationBuilder.AlterColumn<long>(
                name: "Id_Projet",
                table: "Projet",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CollaborateurActivite",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjetThematique",
                table: "ProjetThematique",
                columns: new[] { "id_client", "id_projet", "id_thematique" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjetGalerie",
                table: "ProjetGalerie",
                columns: new[] { "id_client", "Id_Projet", "Id_Image" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projet",
                table: "Projet",
                columns: new[] { "Id_Projet", "Id_Client" });
        }
    }
}
