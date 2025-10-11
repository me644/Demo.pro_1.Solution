using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class emlpye : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(13)");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(13)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_oN",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComputedColumnSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_oN",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "10, 10");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 2"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_BY = table.Column<int>(type: "int", nullable: false),
                    Created_oN = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()"),
                    Modified_bY = table.Column<int>(type: "int", nullable: false),
                    Modified_oN = table.Column<DateTime>(type: "datetime2", nullable: true, computedColumnSql: "GetDate()"),
                    Is_delated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Departments",
                type: "varchar(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Departments",
                type: "varchar(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_oN",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "10, 10")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_oN",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                computedColumnSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
