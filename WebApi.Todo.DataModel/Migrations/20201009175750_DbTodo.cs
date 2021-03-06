﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Todo.DataModel.Migrations
{
    public partial class DbTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new

                {
                Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, "Viktorija", "jovanovska", "(?\\?-??3#>L?q", "ViktorijaJ" });

            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "Id", "Completed", "Description", "Title", "UserId" },
                values: new object[] { 1, false, "Buy Juice", "do this", 1 });

            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "Id", "Completed", "Description", "Title", "UserId" },
                values: new object[] { 2, false, "Learn ASP.NET Core WebApi", "and this", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TodoList_UserId",
                table: "TodoList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
