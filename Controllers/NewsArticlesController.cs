using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News___WebAPI.Models;

namespace News___WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticlesController : ControllerBase
    {
        //Bunların her biri bir endpoint
        [HttpGet]
        public async Task<ActionResult<NewsArticle>> GetById()
        {
            var article = new NewsArticle()
            {
                Id = 1,
                Title="Title",
                Slug="/title",
                PublishedAt=DateTime.Now,
                AuthorName="Auther",
                Content="News Content.",
                Summary="Summary of the news",
                Status=NewsStatus.Draft
            };
            return article;

        }//Bir eylem sonucu döneceğimizi ve bu dönüşün News article içereceğini söylüyoruz
        [HttpPost]
        public async Task<ActionResult<NewsArticle>> Create()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<NewsArticle>> Update()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<NewsArticle>> Delete()
        {
            return Ok();
        }






    }
}
