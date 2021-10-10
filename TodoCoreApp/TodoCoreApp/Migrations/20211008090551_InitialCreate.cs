using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoCoreApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItemDetails",
                columns: table => new
                {
                    TodoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoItemTitle = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    TodoItemDescription = table.Column<string>(type: "nvarchar(170)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemDetails", x => x.TodoItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItemDetails");
        }
    }
}
