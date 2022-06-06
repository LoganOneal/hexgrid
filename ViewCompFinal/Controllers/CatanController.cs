using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
    public class CatanController : Controller
    {
        public IActionResult Index()
        {
            var model = new CatanGrid(2);
            return View(model);
        }

    }
}
