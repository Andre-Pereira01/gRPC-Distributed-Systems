using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrpcServer.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobertura",
                columns: table => new
                {
                    num_administrativo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rua = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    numero = table.Column<int>(type: "int", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    modalidade = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    estado = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cobertura__F37EB4978306F78A", x => x.num_administrativo);
                });

            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operacao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    operador = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    num_administrativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataatual = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Operacoes__3213E83F240AE940", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F8A2C33C3", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobertura");

            migrationBuilder.DropTable(
                name: "Operacoes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
