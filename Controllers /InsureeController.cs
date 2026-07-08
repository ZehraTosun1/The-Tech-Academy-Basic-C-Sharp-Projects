[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
{
    if (ModelState.IsValid)
    {
        decimal quote = 50;

        // Calculate age
        var today = DateTime.Today;
        int age = today.Year - insuree.DateOfBirth.Year;

        if (insuree.DateOfBirth.Date > today.AddYears(-age))
        {
            age--;
        }

        // Age pricing
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

        // Car year pricing
        if (insuree.CarYear < 2000)
        {
            quote += 25;
        }

        if (insuree.CarYear > 2015)
        {
            quote += 25;
        }

        // Porsche pricing
        if (!string.IsNullOrEmpty(insuree.CarMake) && insuree.CarMake.ToLower() == "porsche")
        {
            quote += 25;

            if (!string.IsNullOrEmpty(insuree.CarModel) && insuree.CarModel.ToLower() == "911 carrera")
            {
                quote += 25;
            }
        }

        // Speeding ticket pricing
        quote += insuree.SpeedingTickets * 10;

        // DUI pricing
        if (insuree.DUI)
        {
            quote = quote * 1.25m;
        }

        // Full coverage pricing
        if (insuree.CoverageType)
        {
            quote = quote * 1.50m;
        }

        insuree.Quote = quote;

        db.Insurees.Add(insuree);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    return View(insuree);
}
