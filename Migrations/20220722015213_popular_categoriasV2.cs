using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReryFood.Migrations
{
    public partial class popular_categoriasV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO TB_CATEGORIAS(CATEGORIANOME,DESCRICAO)" +
                                    "VALUES('NORMAL','LANCHE COM INGREDIENTES COMUNS')");

            migrationBuilder.Sql("INSERT INTO TB_CATEGORIAS(CATEGORIANOME,DESCRICAO)" +
                                    "VALUES('NATURAL','LANCHE COM INGREDIENTES NATURAIS')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TB_CATEGORIAS");
        }
    }
}
