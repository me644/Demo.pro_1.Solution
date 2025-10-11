using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class intailcrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    code = table.Column<string>(type: "varchar(13)", nullable: false),
                    name = table.Column<string>(type: "varchar(13)", nullable: false),
                    created_BY = table.Column<int>(type: "int", nullable: false),
                    Created_oN = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()"),
                    Modified_bY = table.Column<int>(type: "int", nullable: false),
                    Modified_oN = table.Column<DateTime>(type: "datetime2", nullable: true, computedColumnSql: "GetDate()"),
                    Is_delated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
