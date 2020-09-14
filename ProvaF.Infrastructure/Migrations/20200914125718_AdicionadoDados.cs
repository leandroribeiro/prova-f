using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaF.Infrastructure.Migrations
{
    public partial class AdicionadoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "Saldo" },
                values: new object[,]
                {
                    { 1, 100 },
                    { 2, 200 },
                    { 3, 300 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
