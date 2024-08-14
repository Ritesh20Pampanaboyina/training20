using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cc9.Models;

namespace cc9.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public ActionResult GetGermanCustomers()
        {
            var germanCustomers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(germanCustomers);
        }
        public ActionResult CustomerByOrderId(int? orderId)
        {
            if (orderId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var customerDetails = db.Orders
                             .Where(o => o.OrderID == orderId)
                             .Select(o => o.Customer)
                             .FirstOrDefault();

            if (customerDetails == null)
            {
                return HttpNotFound();
            }
            return View(customerDetails);
        }
    }
}