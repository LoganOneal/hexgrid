using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
    public class CatanController : Controller
    {
        public IActionResult Index()
        {
            var model = new CatanGrid(3);
            return View(model);
        }



    }
}


// Logan : 1
// Kaitlyn : 1 + .33