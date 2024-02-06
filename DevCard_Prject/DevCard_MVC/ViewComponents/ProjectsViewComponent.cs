using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevCard_MVC.ViewComponents
{
    public class ProjectsViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var projects = new List<Project>()
            {
                new Project(1, "تاکسی", "این یک محصول اول است", "project-1.jpg", "مشتری اول"),
                new Project(2, "فست فود", "این یک محصول اول است", "project-2.jpg", "مشتری دوم"),
                new Project(3, "فضا پیما", "این یک محصول اول است", "project-3.jpg", "مشتری سوم"),
                new Project(4, "اتومبیل", "این یک محصول اول است", "project-4.jpg", "مشتری چهارم"),
            };
            return View("_Projects", projects);
        }
    }
}
