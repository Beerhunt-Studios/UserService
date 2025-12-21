using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixedMusicGenreRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MusicGenre_ParentId",
                schema: "UserService",
                table: "MusicGenre",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicGenre_MusicGenre_ParentId",
                schema: "UserService",
                table: "MusicGenre",
                column: "ParentId",
                principalSchema: "UserService",
                principalTable: "MusicGenre",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicGenre_MusicGenre_ParentId",
                schema: "UserService",
                table: "MusicGenre");

            migrationBuilder.DropIndex(
                name: "IX_MusicGenre_ParentId",
                schema: "UserService",
                table: "MusicGenre");
        }
    }
}
