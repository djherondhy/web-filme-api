using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations
{
    /// <inheritdoc />
    public partial class FilmeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FilmeId = table.Column<int>(type: "int", nullable: true),
                    CinemaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sessoes_cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sessoes_filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "filmes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cinemas_EnderecoId",
                table: "cinemas",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_CinemaId",
                table: "sessoes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_FilmeId",
                table: "sessoes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_enderecos_EnderecoId",
                table: "cinemas",
                column: "EnderecoId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_enderecos_EnderecoId",
                table: "cinemas");

            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "sessoes");

            migrationBuilder.DropIndex(
                name: "IX_cinemas_EnderecoId",
                table: "cinemas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "cinemas");
        }
    }
}
