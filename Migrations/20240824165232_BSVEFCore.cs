using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSVEFCore.Migrations
{
    /// <inheritdoc />
    public partial class BSVEFCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    D_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    D_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.D_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    E_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    E_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    D_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.E_Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Departments",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_D_Id",
                table: "Employees",
                column: "D_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
