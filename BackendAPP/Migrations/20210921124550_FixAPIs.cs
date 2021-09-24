using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPP.Migrations
{
    public partial class FixAPIs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Projet",
                table: "Projet");

            migrationBuilder.AlterColumn<long>(
                name: "Id_Projet",
                table: "Projet",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projet",
                table: "Projet",
                columns: new[] { "Id_Projet", "Id_Client" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Projet",
                table: "Projet");

            migrationBuilder.AlterColumn<long>(
                name: "Id_Projet",
                table: "Projet",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projet",
                table: "Projet",
                column: "Id_Projet");
        }
    }
}
