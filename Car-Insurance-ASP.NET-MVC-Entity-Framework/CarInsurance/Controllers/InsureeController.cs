using System;
using System.Linq;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                decimal quote = 50;

                var today = DateTime.Today;
                int age = today.Year - insuree.DateOfBirth.Year;

                if (insuree.DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }

                if (age <= 18)
                {
                    quote += 100;
                }
                else if (age >= 19 && age <= 25)
                {
                    quote += 50;
                }
                else
                {
                    quote += 25;
                }

                if (insuree.CarYear < 2000)
                {
                    quote += 25;
                }

                if (insuree.CarYear > 2015)
                {
                    quote += 25;
                }

                if (!string.IsNullOrEmpty(insuree.CarMake) && insuree.CarMake.ToLower() == "porsche")
                {
                    quote += 25;

                    if (!string.IsNullOrEmpty(insuree.CarModel) && insuree.CarModel.ToLower() == "911 carrera")
                    {
                        quote += 25;
                    }
                }

                quote += insuree.SpeedingTickets * 10;

                if (insuree.DUI)
                {
                    quote *= 1.25m;
                }

                if (insuree.CoverageType)
                {
                    quote *= 1.50m;
                }

                insuree.Quote = quote;

                db.Insurees.Add(insuree);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(insuree);
        }
    }
}
