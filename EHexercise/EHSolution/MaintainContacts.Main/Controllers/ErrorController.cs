using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintainContacts.Main.Controllers
{
    public class ErrorController : Controller
    {   
        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;

            return View();
        }

        public ActionResult Error()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;

            return View();
        }
    }
}