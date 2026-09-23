using Microsoft.EntityFrameworkCore;
using News___WebAPI.Models;
using static System.Net.WebRequestMethods;

namespace News___WebAPI.Repositories
{
    //uygulama ile veritabanı arasındaki köprü sınıf
    public class NewsDbContext:DbContext
    {

        public NewsDbContext(DbContextOptions<NewsDbContext> options):base(options)
        {
            
        }
        public DbSet<NewsArticle> NewsArticlesTable{ get; set; }//table'nin kendisi

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //C# sınıflarımın veritabanında nasıl temsil edileceğini burada özel olarak yapılandı. FluentAPI(FluentValidation) kullanımı model builder ile gerçekleşiyor.
        }
    }
}
