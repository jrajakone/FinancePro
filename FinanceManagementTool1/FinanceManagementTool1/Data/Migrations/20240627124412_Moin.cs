using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagementTool1.Data.Migrations
{
    public partial class Moin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_addDatas",
                table: "addDatas");

            migrationBuilder.RenameTable(
                name: "addDatas",
                newName: "Ausgaben");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ausgaben",
                table: "Ausgaben",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ausgaben",
                table: "Ausgaben");

            migrationBuilder.RenameTable(
                name: "Ausgaben",
                newName: "addDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addDatas",
                table: "addDatas",
                column: "Id");
        }
    }
}
