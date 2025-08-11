using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoListLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SingleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDoListListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleEntries_ToDoListLists_ToDoListListId",
                        column: x => x.ToDoListListId,
                        principalTable: "ToDoListLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDoListLists",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "SingleEntries",
                columns: new[] { "Id", "Description", "Name", "ToDoListListId" },
                values: new object[,]
                {
                    { 1, "Milk, Bread, Eggs", "Buy groceries", 1 },
                    { 2, "Take the dog for a walk in the park", "Walk the dog", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SingleEntries_ToDoListListId",
                table: "SingleEntries",
                column: "ToDoListListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SingleEntries");

            migrationBuilder.DropTable(
                name: "ToDoListLists");
        }
    }
}
