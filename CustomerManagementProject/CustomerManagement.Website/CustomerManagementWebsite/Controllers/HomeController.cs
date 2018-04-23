using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerManagementServices;

namespace CustomerManagementWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("GetAllCustomers");
        }

        public ActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return View(customers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}