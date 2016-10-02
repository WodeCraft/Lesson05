using System.Collections.Generic;
using System.Web.Mvc;

namespace Lesson05.Controllers
{
    public class Exercise03Controller : Controller
    {
        // GET: Exercise03
        public ActionResult Index()
        {
            List<SelectListItem> breakfastTypes = new List<SelectListItem>();
            breakfastTypes.Add(new SelectListItem { Text = "Cornflakes", Value = "cornflakes" });
            breakfastTypes.Add(new SelectListItem { Text = "Egg", Value = "egg" });
            breakfastTypes.Add(new SelectListItem { Text = "Toast", Value = "toast" });
            breakfastTypes.Add(new SelectListItem { Text = "Juice", Value = "juice" });
            breakfastTypes.Add(new SelectListItem { Text = "Milk", Value = "milk" });
            breakfastTypes.Add(new SelectListItem { Text = "Coffee", Value = "coffee" });
            breakfastTypes.Add(new SelectListItem { Text = "Tea", Value = "tea" });

            ViewBag.BreakfastTypes = breakfastTypes;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {

            return View();
        }
    }
}