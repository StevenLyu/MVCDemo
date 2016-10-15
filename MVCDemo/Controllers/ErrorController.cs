using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageNotFound(string aspxerrorpath)
        {
            ViewBag.error_path = aspxerrorpath;
            return View();
        }
    }
}