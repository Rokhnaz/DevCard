using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;
using System.Web.Mvc;
using DevCard_MVC.Data;
using Microsoft.AspNetCore.Mvc.Formatters;
using NuGet.ProjectModel;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using FileResult = Microsoft.AspNetCore.Mvc.FileResult;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace DevCard_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Service> _services = new List<Service>()
        {
            new Service(1, "??????"),
            new Service(2, "???? ??"),
            new Service(3, "?????"),
            new Service(4, "?????"),
        };
        public IActionResult Index()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult ProjectDetails(long id)
        {
            var project = ProjectStore.GetProjectBy(id);

            return View(project);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Contact()
        {
            var model = new Contact()
            {
                Services = new SelectList(_services, "Id", "Name")

            };
            return View(model);
        }

        //public ContentResult cresult()
        //{
        //    return Content($"<h1>Hello my love Reza</h1><script>Confirm('this is AbandonedMutexException script')</script>", "text/html");
        //}

        //public FileResult FResult()
        //{
        //    return File("~/txttest.txt", "text/html");
        //}

        public FileResult FileResult()
        {
            var readfile = System.IO.File.ReadAllBytes("wwwroot/txttest.txt");
            const string FName = "MyFileD.txt";
            return File(readfile, MediaTypeNames.Text.RichText, FName);

        }

        public JavaScriptResult jsr()
        {
            return new JavaScriptResult(" alert('Hellooooo')");
        }

        public class JavaScriptResult : ContentResult
        {
            public JavaScriptResult(string data)
            {
                Content = data;
                ContentType = "Application/javascript";
            }
        }

        public IActionResult test()
        {
            return new StatusCodeResult(404);
        }

        //[HttpPost]
        //public JsonResult Contact(IFormCollection form)
        //{
        //    var name = form["name"];
        //    return Json(name);
        //}
        //[HttpPost]
        //public JsonResult Contact(Contact form)
        //{
        //    Console.WriteLine(form.ToString());
        //    return Json(Ok());
        //}

        [System.Web.Mvc.HttpPost]
        public IActionResult Contact(Contact model)
        {
            model.Services = new SelectList(_services, "Id", "Name");
            if (!ModelState.IsValid)
            {
                ViewBag.error = "??????? ?? ?????? ??? ???";
                return View(model);
            }

            // return RedirectToAction("Index");
            ModelState.Clear();
            model = new Contact();
            model.Services = new SelectList(_services, "Id", "Name");
            ViewBag.success = "???? ??? ?? ?????? ??? ?? ?? ????";
            return View(model);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
