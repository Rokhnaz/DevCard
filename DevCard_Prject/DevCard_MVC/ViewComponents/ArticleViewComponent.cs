using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevCard_MVC.ViewComponents
{
    public class LatestArticlesViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var LatestArticles = new List<Article>()
            {
                new Article(1, "مقاله اول", "توضیحات مقاله اول", "blog-post-thumb-1.jpg"),
                new Article(2, "مقاله اول", "توضیحات مقاله اول", "blog-post-thumb-2.jpg"),
                new Article(3, "مقاله اول", "توضیحات مقاله اول", "blog-post-thumb-3.jpg"),
                new Article(4, "مقاله اول", "توضیحات مقاله اول", "blog-post-thumb-4.jpg"),
            };
            return View("_LatestArticles",LatestArticles);
        }
    }
}
