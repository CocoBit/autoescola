using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoEscola.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Title = "Auto Escola Simples, o melhor sistema para Auto Escola (CFC) do Brasil";
            ViewBag.Login = "index";
            return View();
        }
    }
}
