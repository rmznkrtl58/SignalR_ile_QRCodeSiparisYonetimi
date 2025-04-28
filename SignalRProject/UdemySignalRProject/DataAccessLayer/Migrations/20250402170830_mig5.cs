using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableTableId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_MenuTableTableId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "MenuTableTableId",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Baskets",
                newName: "MenuTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_MenuTableId",
                table: "Baskets",
                column: "MenuTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets",
                column: "MenuTableId",
                principalTable: "MenuTables",
                principalColumn: "TableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_MenuTableId",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "MenuTableId",
                table: "Baskets",
                newName: "TableId");

            migrationBuilder.AddColumn<int>(
                name: "MenuTableTableId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_MenuTableTableId",
                table: "Baskets",
                column: "MenuTableTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableTableId",
                table: "Baskets",
                column: "MenuTableTableId",
                principalTable: "MenuTables",
                principalColumn: "TableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
