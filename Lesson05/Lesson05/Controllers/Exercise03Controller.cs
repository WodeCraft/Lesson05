using Lesson05.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Lesson05.Controllers
{
    public class Exercise03Controller : Controller
    {
        Dictionary<string, decimal> breakfastTypesDict = new Dictionary<string, decimal> {
            { "Cornflakes", 17.25M },
            { "Egg", 15.75M },
            { "Toast", 12.50M },
            { "Juice", 18M },
            { "Milk", 15M },
            { "Coffee", 14.25M },
            { "Tea", 12.50M }
       };

        // GET: Exercise03
        public ActionResult Index()
        {
            List<SelectListItem> listBreakfastTypes = new List<SelectListItem>();
            listBreakfastTypes.Add(new SelectListItem { Text = "Cornflakes", Value = "Cornflakes" });
            listBreakfastTypes.Add(new SelectListItem { Text = "Egg", Value = "Egg" });
            listBreakfastTypes.Add(new SelectListItem { Text = "Toast", Value = "Toast" });
            listBreakfastTypes.Add(new SelectListItem { Text = "Juice", Value = "Juice" });
            listBreakfastTypes.Add(new SelectListItem { Text = "Milk", Value = "Milk" });
            listBreakfastTypes.Add(new SelectListItem { Text = "Coffee", Value = "Coffee" });
            listBreakfastTypes.Add(new SelectListItem { Text = "Tea", Value = "Tea" });

            ViewBag.BreakfastTypes = listBreakfastTypes;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {

            string[] menuItems = fc["menuitem"].Split(',');
            List<string> selectedBreakfast = new List<string>();
            decimal totalPrice = 0M;
            foreach (string breakfastItem in menuItems)
            {
                if (!"false".Equals(breakfastItem))
                {
                    var breakfastType = breakfastTypesDict.Where(bt => bt.Key.Equals(breakfastItem)).Single();
                    selectedBreakfast.Add(string.Format("{0} ({1:0.00})", breakfastItem, breakfastType.Value));
                    totalPrice += breakfastType.Value;
                }
            }

            DateTime deliveryDate = DateTime.Parse(fc["time"]);

            ViewBag.Fullname = fc["fullname"];
            ViewBag.RoomNumber = fc["roomnumber"];
            ViewBag.Order = string.Join(", ", selectedBreakfast);
            ViewBag.Time = deliveryDate.ToString("D", CultureInfo.CreateSpecificCulture("en-us"));
            ViewBag.TotalPrice = totalPrice;

            return View("Receipt");
        }


        public ActionResult WithModel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WithModel(BreakfastOrder breakfastOrder, string[] menuitem)
        {
            //string[] menuItems = menuitem.Split(',');
            List<string> selectedBreakfast = new List<string>();
            decimal totalPrice = 0M;
            foreach (string breakfastItem in menuitem)
            {
                if (!"false".Equals(breakfastItem))
                {
                    var breakfastType = breakfastTypesDict.Where(bt => bt.Key.Equals(breakfastItem)).Single();
                    selectedBreakfast.Add(string.Format("{0} ({1:0.00})", breakfastItem, breakfastType.Value));
                    totalPrice += breakfastType.Value;
                }
            }

            breakfastOrder.Breakfast = string.Join(", ", selectedBreakfast);
            breakfastOrder.TotalOrderPrice = totalPrice;

            return View("WithModelReceipt", breakfastOrder);
        }
    }
}