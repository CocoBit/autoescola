using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoEscola.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        //
        // GET: /Admin/HomeAdmin/

        public ActionResult Index()
        {
            ViewBag.Login = "admin";
            return View();
        }

    }
}
