using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagementTool1.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ausgaben",
                table: "Ausgaben");

            migrationBuilder.RenameTable(
                name: "Ausgaben",
                newName: "AddData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddData",
                table: "AddData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AddData",
                table: "AddData");

            migrationBuilder.RenameTable(
                name: "AddData",
                newName: "Ausgaben");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ausgaben",
                table: "Ausgaben",
                column: "Id");
        }
    }
}
