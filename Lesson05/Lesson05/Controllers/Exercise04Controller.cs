using Lesson05.Models;
using System.Web.Mvc;

namespace Lesson05.Controllers
{
    public class Exercise04Controller : Controller
    {
        // GET: Exercise04
        public ActionResult Index()
        {

            return View(new ParkingTicketMachine());
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            ParkingTicketMachine ptm = new ParkingTicketMachine();

            int amountInserted;
            if (int.TryParse(fc["amountInserted"], out amountInserted))
            {
                ptm.InsertCoin(amountInserted);
            }

            switch (fc["kr"])
            {
                case "1 kr":
                default:
                    ptm.InsertCoin(1);
                    break;
                case "2 kr":
                    ptm.InsertCoin(2);
                    break;
                case "5 kr":
                    ptm.InsertCoin(5);
                    break;
                case "10 kr":
                    ptm.InsertCoin(10);
                    break;
                case "20 kr":
                    ptm.InsertCoin(20);
                    break;
            }

            if (fc["cancel"] != null)
            {
                ptm = new ParkingTicketMachine();
                ptm.Info = amountInserted + " kr is paid back";
            }
            else if (fc["confirm"] != null)
            {
                return View("confirm", ptm);
            }
            else
            {
                ptm.Info = ptm.AmountInserted + " kr inserted";
            }

            return View(ptm);
        }
    }
}