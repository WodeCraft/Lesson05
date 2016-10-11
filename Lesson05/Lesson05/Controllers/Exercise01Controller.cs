using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lesson05.Controllers
{
    public class Exercise01Controller : Controller
    {
        private List<SelectListItem> countryList = new List<SelectListItem>();

        // GET: Exercise01
        public ActionResult Index(string countries)
        {
            if (Session["countryList"] == null)
            {
                countryList.Add(new SelectListItem { Text = "Gambia", Value = "GM" });
                countryList.Add(new SelectListItem { Text = "Finland", Value = "FI" });
                countryList.Add(new SelectListItem { Text = "United Kingdom", Value = "UK" });
                countryList.Add(new SelectListItem { Text = "Denmark", Value = "DK" });
                countryList.Add(new SelectListItem { Text = "Japan", Value = "JP" });
                countryList.Add(new SelectListItem { Text = "Jordan", Value = "JO" });
                countryList.Add(new SelectListItem { Text = "Kenya", Value = "KE" });
                countryList.Add(new SelectListItem { Text = "France", Value = "FR" });
                countryList.Add(new SelectListItem { Text = "Czech", Value = "CZ" });
                countryList.Add(new SelectListItem { Text = "Italy", Value = "IT" });
                countryList.Add(new SelectListItem { Text = "Norway", Value = "NO" });
                countryList.Add(new SelectListItem { Text = "Sweden", Value = "SE" });
                countryList.Add(new SelectListItem { Text = "Estonia", Value = "EE" });
                Session["countryList"] = countryList;
            }
            else
            {
                countryList = (List<SelectListItem>)Session["countryList"];
            }

            ViewBag.Countries = countryList;
            ViewBag.CountryCode = countries;

            return View();
        }

        /// <summary>
        /// What is the difference between calling the method with:
        /// 
        /// Index(FormCollection fc)
        /// 
        /// And
        /// 
        /// Index(string country, string code)
        /// 
        /// The result is that the former will reset the TextBoxes, but the latter will leave the values in there. Why is that?
        /// Does that has something to do with me using the Html.TextBox helper?
        ///
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string country = fc["country"];
            string code = fc["code"];

            if (Session["countryList"] != null)
            {
                countryList = (List<SelectListItem>)Session["countryList"];
            }

            countryList.Add(new SelectListItem { Text = country, Value = code });

            // Using Linq to sort the list
            //countryList = countryList.OrderBy(li => li.Text).ToList<SelectListItem>();

            // Using a Lambda expression to sort the list
            countryList.Sort((a, b) => a.Text.CompareTo(b.Text));

            // Select the newly inserted Country
            // Can be used by both Linq and Lambda version
            countryList.Where(c => c.Value == code).Single().Selected = true;

            // Using the utility class
            // This method will make it possible to reset the selected item in the list
            //Utilities.SortSelectList(countryList, code);

            ViewBag.Countries = countryList;
            ViewBag.CountryCode = code;

            return View();
        }

    }
}