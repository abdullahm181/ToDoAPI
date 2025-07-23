using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todo.Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TodoCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoCategories_TodoCategoryId",
                        column: x => x.TodoCategoryId,
                        principalTable: "TodoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TodoCategories",
                columns: new[] { "Id", "CreateDate", "Description", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 23, 15, 17, 57, 685, DateTimeKind.Local).AddTicks(6975), "Work related tasks", "Work", new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6007) },
                    { 2, new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6531), "Personal tasks", "Personal", new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6534) },
                    { 3, new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6537), "Shopping tasks", "Shopping", new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6538) },
                    { 4, new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6540), "Health related tasks", "Health", new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6541) },
                    { 5, new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6543), "Fitness related tasks", "Fitness", new DateTime(2025, 7, 23, 15, 17, 57, 687, DateTimeKind.Local).AddTicks(6543) }
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "CreateDate", "DueDate", "IsDone", "Note", "Title", "TodoCategoryId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1132), new DateTime(2025, 7, 24, 15, 17, 57, 697, DateTimeKind.Local).AddTicks(9643), false, "This is the first todo", "First Todo", 1, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1506) },
                    { 2, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1881), new DateTime(2025, 7, 25, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1869), false, "This is the second todo", "Second Todo", 2, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1882) },
                    { 3, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1886), new DateTime(2025, 7, 26, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1884), false, "This is the third todo", "Third Todo", 3, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1887) },
                    { 4, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1890), new DateTime(2025, 7, 27, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1889), false, "This is the fourth todo", "Fourth Todo", 4, new DateTime(2025, 7, 23, 15, 17, 57, 698, DateTimeKind.Local).AddTicks(1891) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoCategoryId",
                table: "TodoItems",
                column: "TodoCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoCategories");
        }
    }
}
