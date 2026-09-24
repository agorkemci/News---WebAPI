using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News___WebAPI.Models;
using News___WebAPI.Repositories;

namespace News___WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticlesController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;

        public NewsArticlesController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetAll(CancellationToken cancellation)
        {
            var articles = await _newsRepository.GetAllAsync(cancellation);
            return Ok(articles);
        }


        //Bunların her biri bir endpoint
        [HttpGet("{id:int}")]
        public async Task<ActionResult<NewsArticle>> GetById(int id)
        {
            var article = await _newsRepository.GetByIdAsync(id);
            if (article is null)
                return NotFound(); //404
            return Ok(article); //200

        } //Bir eylem sonucu döneceğimizi ve bu dönüşün News article içereceğini söylüyoruz
        [HttpPost]
        public async Task<ActionResult<NewsArticle>> Create([FromBody]NewsArticle newsArticle,CancellationToken cancellationToken)
        {
            //FromBody ile Kullanıcının gönderdiği paketlenmiş veriyi (başlık, metin vb.) alır ve sistemin anlayacağı bir haber nesnesine çevirir.
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            var created=await _newsRepository.AddAsync(newsArticle,cancellationToken);// Gelen haberi veritabanına kaydeder.
            return CreatedAtAction(
                nameof(GetById),           // 1. Nereye baksın? (Hedef metodun adı)
                new { id = created.Id },   // 2. Oraya giderken hangi bilgileri götürsün? (URL parametreleri)
                created                    // 3. Kullanıcının eline neyi teslim etsin? (Kaydedilen haberin kendisi)
            );
        }
        [HttpPut]
        public async Task<ActionResult<NewsArticle>> Update([FromRoute] int id, [FromBody] NewsArticle  newsArticle, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            if (id != newsArticle.Id)
                return BadRequest("Route data is not valid!");
            var existing = await _newsRepository.GetByIdAsync(id,cancellationToken);
            if (existing is null)
                return NotFound();//404

            await _newsRepository.UpdateAsync(newsArticle, cancellationToken);
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            var existing = await _newsRepository.GetByIdAsync(id, cancellationToken);
            if (existing is null)
                return NotFound(); // 404

            await _newsRepository.DeleteAsync(id, cancellationToken);
            return NoContent(); // 204
        }






    }
}
