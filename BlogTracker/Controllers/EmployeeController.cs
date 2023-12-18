using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTracker.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult SaveBlog()
        {
            return View();
        }
        public ActionResult BlogList()
        {
            return View();
        }
    }
}