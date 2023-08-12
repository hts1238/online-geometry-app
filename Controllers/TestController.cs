using Microsoft.AspNetCore.Mvc;
using OnlineGeometryApp.Models;

namespace OnlineGeometryApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test(string id, string desc)
        {
            TestModel model = new TestModel();
            model.Id = int.Parse(id);
            model.Name = "Name";
            model.Description = desc;

            return View(model);
        }
    }
}
