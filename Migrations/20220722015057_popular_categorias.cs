using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReryFood.Migrations
{
    public partial class popular_categorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lanches_TB_Categorias_CategoriaId",
                table: "Lanches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lanches",
                table: "Lanches");

            migrationBuilder.RenameTable(
                name: "Lanches",
                newName: "TB_Lanches");

            migrationBuilder.RenameIndex(
                name: "IX_Lanches_CategoriaId",
                table: "TB_Lanches",
                newName: "IX_TB_Lanches_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Lanches",
                table: "TB_Lanches",
                column: "LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Lanches_TB_Categorias_CategoriaId",
                table: "TB_Lanches",
                column: "CategoriaId",
                principalTable: "TB_Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Lanches_TB_Categorias_CategoriaId",
                table: "TB_Lanches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Lanches",
                table: "TB_Lanches");

            migrationBuilder.RenameTable(
                name: "TB_Lanches",
                newName: "Lanches");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Lanches_CategoriaId",
                table: "Lanches",
                newName: "IX_Lanches_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lanches",
                table: "Lanches",
                column: "LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lanches_TB_Categorias_CategoriaId",
                table: "Lanches",
                column: "CategoriaId",
                principalTable: "TB_Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
