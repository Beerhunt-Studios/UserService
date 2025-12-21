using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedMusicGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                schema: "UserService",
                table: "UserInformation",
                newName: "LastName");

            migrationBuilder.CreateTable(
                name: "MusicGenre",
                schema: "UserService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicGenreUserInformation",
                schema: "UserService",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    UserInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenreUserInformation", x => new { x.GenreId, x.UserInformationId });
                    table.ForeignKey(
                        name: "FK_MusicGenreUserInformation_MusicGenre_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "UserService",
                        principalTable: "MusicGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicGenreUserInformation_UserInformation_UserInformationId",
                        column: x => x.UserInformationId,
                        principalSchema: "UserService",
                        principalTable: "UserInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicGenreUserInformation_UserInformationId",
                schema: "UserService",
                table: "MusicGenreUserInformation",
                column: "UserInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicGenreUserInformation",
                schema: "UserService");

            migrationBuilder.DropTable(
                name: "MusicGenre",
                schema: "UserService");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "UserService",
                table: "UserInformation",
                newName: "Lastname");
        }
    }
}
