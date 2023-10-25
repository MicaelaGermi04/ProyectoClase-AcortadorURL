using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoClase_Practica.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Categoria 1" },
                    { 2, "Categoria 2" },
                    { 3, "Categoria 3" }
                });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "CategoryId", "LongUrl", "ShortUrl", "Visit" },
                values: new object[,]
                {
                    { 1, 1, "https://www.youtube.com/watch?v=8cKvvmPwgP4&list=RD8cKvvmPwgP4&start_radio=1&ab_channel=ElCanserbero", "g9Kr21", 0 },
                    { 2, 1, "https://www.youtube.com/watch?v=v_zZmsFZDaM&list=RD8cKvvmPwgP4&index=2&ab_channel=elvecindariocalle13", "jrE43Ps", 0 },
                    { 3, 2, "https://www.youtube.com/watch?v=8SOr5IEAxbc&ab_channel=PeloMusicGroup", "4fOd9S", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
