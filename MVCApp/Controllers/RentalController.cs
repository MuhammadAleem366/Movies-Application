using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult RentalForm()
        {
            return View();
        }
    }
}