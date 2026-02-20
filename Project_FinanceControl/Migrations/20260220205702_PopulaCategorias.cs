using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_FinanceControl.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT into Categories(Name,UserId) values('Salário', '1')");
            mb.Sql("INSERT into Categories(Name,UserId) values('Faculdade', '1')");
            mb.Sql("INSERT into Categories(Name,UserId) values('Academia', '1')");

            mb.Sql("INSERT into Categories(Name,UserId) values('Carro', '2')");
            mb.Sql("INSERT into Categories(Name,UserId) values('Empregada', '2')");
            mb.Sql("INSERT into Categories(Name,UserId) values('Dentista', '2')");

            mb.Sql("INSERT into Categories(Name,UserId) values('Pet Shop', '3')");
            mb.Sql("INSERT into Categories(Name,UserId) values('Cartao de Credito', '3')");
            mb.Sql("INSERT into Categories(Name,UserId) values('Viagem', '3')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE From Categories");   
        }
    }
}
