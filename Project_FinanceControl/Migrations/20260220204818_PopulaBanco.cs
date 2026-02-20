using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace Project_FinanceControl.Migrations
{
    /// <inheritdoc />
    public partial class PopulaBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("INSERT into Users(Name,Email,Password,DateCreated) values('Julio Mattos', 'julio@gmail.com', 'senha123',now())");
            mb.Sql("INSERT into Users(Name,Email,Password,DateCreated) values('Joãozinho', 'joao@gmail.com', 'senha123',now())");
            mb.Sql("INSERT into Users(Name,Email,Password,DateCreated) values('Camargo', 'camargo@gmail.com', 'senha123',now())");
            mb.Sql("INSERT into Users(Name,Email,Password,DateCreated) values('Maria', 'maria123@gmail.com', 'senha123',now())");

        }

        
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE From Users");
        }
    }
}
