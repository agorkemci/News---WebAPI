using News___WebAPI.Models;

namespace News___WebAPI.Repositories
{
    public interface INewsRepository
    {
        Task<List<NewsArticle>> GetAllAsync(CancellationToken cancellationToken=default);//async olduğu için iptal edilebilir.

        Task<NewsArticle> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<NewsArticle> AddAsync(NewsArticle newsArticle, CancellationToken cancellationToken= default);

        void UpdateAsync(NewsArticle newsArticle, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);





    }
}
