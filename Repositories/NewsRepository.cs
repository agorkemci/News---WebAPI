using Microsoft.EntityFrameworkCore;
using News___WebAPI.Models;

namespace News___WebAPI.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsDbContext newsDbContext;

        public NewsRepository(NewsDbContext newsDbContext)
        {
            this.newsDbContext = newsDbContext;//Veritabanıyla konuşan EF Core nesnesi
        }

        public async Task<NewsArticle> AddAsync(NewsArticle newsArticle, CancellationToken cancellationToken = default)
        {
            await newsDbContext.NewsArticlesTable.AddAsync(newsArticle, cancellationToken);//Entity Framework Core'da bir nesneyi veritabanına eklenmek üzere hazırlamak için kullanılır.
            await newsDbContext.SaveChangesAsync(cancellationToken);
            return newsArticle;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await newsDbContext.NewsArticlesTable.FindAsync(id,cancellationToken);
            if (entity is null)
                return;
            newsDbContext.NewsArticlesTable.Remove(entity);
            await newsDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<NewsArticle>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await newsDbContext.NewsArticlesTable.AsNoTracking().OrderByDescending(x=>x.PublishedAt).ThenBy(ar=>ar.Id).ToListAsync(cancellationToken);
        }

        public async Task<NewsArticle?> GetByIdAsync(
         int id,
         CancellationToken cancellationToken = default)
        {
            var entity = await newsDbContext.NewsArticlesTable
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity;
        }

        public async void UpdateAsync(NewsArticle newsArticle, CancellationToken cancellationToken = default)
        {
            newsDbContext.NewsArticlesTable.Update(newsArticle);
            await newsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
