using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;

namespace DevCard_MVC.Controllers
{
    public class TestController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //public IActionResult Index()
        //{
        //    return View("Footer");
        //}

        //public FileResult index()
        //{
        //   // return File("~/txttest.txt", "Text/html");
        //   var readFile = System.IO.File.ReadAllBytes("wwwroot/txttest.txt");
        //   const string fileName = "myFile.txt";
        //   return File(readFile, MediaTypeNames.Text.Plain, fileName);
        //}

        //public JsonResult index()
        //{
        //    return Json(new { id = 1, name = "Reza", job = "Accounter", site = "arad.com" });
        //}

        //public JavascriptResult index()
        //{
        //    return new JavascriptResult("alert( 'Salam Salam hamegi salam ey zendegi salam')");
        //}
        //public class JavascriptResult:ContentResult
        //{
        //    public JavascriptResult(string data)
        //    {
        //        Content = data;
        //        ContentType = "application/javascript";
        //    }
        //}

        //public RedirectResult index()
        //{
        //    return Redirect("http://atriya.com");
        //}

        //public RedirectToActionResult index()
        //{
        //    return RedirectToAction("Contact", "Home");
        //}

        //public IActionResult index()
        //{
        //    //return new OkResult();
        //   // return new NotFoundResult();
        //  // return new BadRequestResult();
        //  //return new NoContentResult();
        //  return new StatusCodeResult(510);
        //}



    }
}
