using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace News___WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "NewsArticlesTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "NewsArticlesTable",
                type: "nvarchar(220)",
                maxLength: 220,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(222)",
                oldMaxLength: 222);

            migrationBuilder.InsertData(
                table: "NewsArticlesTable",
                columns: new[] { "Id", "AuthorName", "Content", "PublishedAt", "Slug", "Status", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "Ahmet Yılmaz", "Yapay zeka destekli araçlar, test otomasyonundan kod optimizasyonuna kadar tüm yazılım yaşam döngüsünü kökten değiştiriyor. Geliştiriciler rutin görevleri devrederken mimari tasarıma daha fazla odaklanabiliyor...", new DateTime(2026, 1, 15, 10, 30, 0, 0, DateTimeKind.Utc), "yapay-zeka-ve-yazilim-dunyasindaki-yeni-gelismeler", "Published", "Yapay zeka teknolojilerinin modern yazılım geliştirme süreçlerine etkileri ve sektörel beklentiler.", "Yapay Zeka ve Yazılım Dünyasındaki Yeni Gelişmeler" },
                    { 2, "Selin Demir", ".NET 10 sürümüyle birlikte runtime üzerinde yapılan derinlemesine iyileştirmeler sayesinde Web API uç noktalarında yanıt süreleri ciddi oranda düşmüş durumda...", new DateTime(2026, 2, 20, 14, 0, 0, 0, DateTimeKind.Utc), "dotnet-10-ile-gelen-performans-iyilestirmeleri", "Published", "Yeni .NET sürümünün getirdiği JIT optimizasyonları ve bellek yönetimi avantajları.", ".NET 10 ile Gelen Performans İyileştirmeleri" },
                    { 3, "Burak Kaya", "Monolitik yapıdan mikroservislere geçerken karşılaşılan en büyük zorluklardan biri veritabanı ayrımıdır. Bu yazıda Outbox Pattern ve event-driven çözümleri ele alıyoruz...", null, "mikroservis-mimarilerinde-veri-tutarliigi", "Draft", "Dağıtık sistemlerde ACID yerine nihai tutarlılık (eventual consistency) prensipleri.", "Mikroservis Mimarilerinde Veri Tutarlılığı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticlesTable_Slug",
                table: "NewsArticlesTable",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsArticlesTable_Slug",
                table: "NewsArticlesTable");

            migrationBuilder.DeleteData(
                table: "NewsArticlesTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NewsArticlesTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NewsArticlesTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "NewsArticlesTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "NewsArticlesTable",
                type: "nvarchar(222)",
                maxLength: 222,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(220)",
                oldMaxLength: 220);
        }
    }
}
