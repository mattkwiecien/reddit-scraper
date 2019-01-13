using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestSite.Models;

namespace TestSite.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            var sd = new SampleData();
            return View(sd);
        }

        public IActionResult ViewDetail(int id) {
            SampleData sd = new SampleData();
            sd.SetSelected(id);
            return View(sd);
        }

        [HttpPost()]
        [ActionName("FormData")]
        public IActionResult FormDataPost() {
            var fd = Request.Form;
            ViewBag.Name = fd["UserName"];
            ViewBag.Gender = fd["Gender"];
            return View("~/Views/Home/PostSuccess.cshtml");
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
