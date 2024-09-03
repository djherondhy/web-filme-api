using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations
{
    /// <inheritdoc />
    public partial class FilmeCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_cinemas_CinemaId",
                table: "sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes");

            migrationBuilder.DropIndex(
                name: "IX_sessoes_CinemaId",
                table: "sessoes");

            migrationBuilder.DropIndex(
                name: "IX_sessoes_FilmeId",
                table: "sessoes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sessoes",
                newName: "FilmeId1");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId1",
                table: "sessoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes",
                columns: new[] { "FilmeId", "CinemaId" });

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_FilmeId1",
                table: "sessoes",
                column: "FilmeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_cinemas_FilmeId",
                table: "sessoes",
                column: "FilmeId",
                principalTable: "cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_filmes_FilmeId1",
                table: "sessoes",
                column: "FilmeId1",
                principalTable: "filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_cinemas_FilmeId",
                table: "sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_filmes_FilmeId1",
                table: "sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes");

            migrationBuilder.DropIndex(
                name: "IX_sessoes_FilmeId1",
                table: "sessoes");

            migrationBuilder.RenameColumn(
                name: "FilmeId1",
                table: "sessoes",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "sessoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_CinemaId",
                table: "sessoes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_FilmeId",
                table: "sessoes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_cinemas_CinemaId",
                table: "sessoes",
                column: "CinemaId",
                principalTable: "cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes",
                column: "FilmeId",
                principalTable: "filmes",
                principalColumn: "Id");
        }
    }
}
