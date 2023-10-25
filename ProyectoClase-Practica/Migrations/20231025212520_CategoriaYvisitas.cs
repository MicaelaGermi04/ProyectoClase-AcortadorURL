using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoClase_Practica.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaYvisitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Urls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visit",
                table: "Urls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_CategoryId",
                table: "Urls",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_Category_CategoryId",
                table: "Urls",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_Category_CategoryId",
                table: "Urls");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Urls_CategoryId",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "Visit",
                table: "Urls");
        }
    }
}
