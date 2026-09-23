using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News___WebAPI.Models;

namespace News___WebAPI.Repositories.Configuration
{
    public class NewsArticleConfiguration : IEntityTypeConfiguration<NewsArticle>
    {
        public void Configure(EntityTypeBuilder<NewsArticle> builder)
        {
            builder.HasKey(article=>article.Id);
            builder.Property(article => article.Title).IsRequired().HasMaxLength(200);
            builder.Property(article=>article.Slug).IsRequired().HasMaxLength(220);
            builder.HasIndex(article => article.Slug).IsUnique();
            builder.Property(article => article.Summary).HasMaxLength(500);
            builder.Property(article=>article.Content).IsRequired();
            builder.Property(article => article.AuthorName).IsRequired().HasMaxLength(100);
            builder.Property(article => article.Status).HasConversion<string>().IsRequired();
            builder.HasData(
                new NewsArticle
                {
                    Id = 1,
                    Title = "Yapay Zeka ve Yazılım Dünyasındaki Yeni Gelişmeler",
                    Slug = "yapay-zeka-ve-yazilim-dunyasindaki-yeni-gelismeler",
                    Summary = "Yapay zeka teknolojilerinin modern yazılım geliştirme süreçlerine etkileri ve sektörel beklentiler.",
                    Content = "Yapay zeka destekli araçlar, test otomasyonundan kod optimizasyonuna kadar tüm yazılım yaşam döngüsünü kökten değiştiriyor. Geliştiriciler rutin görevleri devrederken mimari tasarıma daha fazla odaklanabiliyor...",
                    AuthorName = "Ahmet Yılmaz",
                    Status = NewsStatus.Published,
                    PublishedAt = new DateTime(2026, 1, 15, 10, 30, 0, DateTimeKind.Utc)
                },
                new NewsArticle
                {
                    Id = 2,
                    Title = ".NET 10 ile Gelen Performans İyileştirmeleri",
                    Slug = "dotnet-10-ile-gelen-performans-iyilestirmeleri",
                    Summary = "Yeni .NET sürümünün getirdiği JIT optimizasyonları ve bellek yönetimi avantajları.",
                    Content = ".NET 10 sürümüyle birlikte runtime üzerinde yapılan derinlemesine iyileştirmeler sayesinde Web API uç noktalarında yanıt süreleri ciddi oranda düşmüş durumda...",
                    AuthorName = "Selin Demir",
                    Status = NewsStatus.Published,
                    PublishedAt = new DateTime(2026, 2, 20, 14, 0, 0, DateTimeKind.Utc)
                },
                new NewsArticle
                {
                    Id = 3,
                    Title = "Mikroservis Mimarilerinde Veri Tutarlılığı",
                    Slug = "mikroservis-mimarilerinde-veri-tutarliigi",
                    Summary = "Dağıtık sistemlerde ACID yerine nihai tutarlılık (eventual consistency) prensipleri.",
                    Content = "Monolitik yapıdan mikroservislere geçerken karşılaşılan en büyük zorluklardan biri veritabanı ayrımıdır. Bu yazıda Outbox Pattern ve event-driven çözümleri ele alıyoruz...",
                    AuthorName = "Burak Kaya",
                    Status = NewsStatus.Draft,
                    PublishedAt = null
                }
            );


        }
    }
}
