using DevCard_MVC.Models;

namespace DevCard_MVC.Data
{
    public  static  class  ProjectStore
    {
        public  static  List<Project> GetProjects()
        {
            return  new List<Project>
            {
                new Project(1, "تاکسی", "این یک محصول اول است", "project-1.jpg", "مشتری اول"),
                new Project(2, "فست فود", "این یک محصول دوم است", "project-2.jpg", "مشتری دوم"),
                new Project(3, "فضا پیما", "این یک محصول سوم است", "project-3.jpg", "مشتری سوم"),
                new Project(4, "اتومبیل", "این یک محصول چهارم است", "project-4.jpg", "مشتری چهارم"),
            };
        }

        public static  Project GetProjectBy(long id)
        {
            return GetProjects().FirstOrDefault(x => x.Id == id);

        }
    }
}
