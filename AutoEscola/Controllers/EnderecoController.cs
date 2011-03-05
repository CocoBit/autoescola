using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;

namespace AutoEscola.Controllers
{
    public class EnderecoController : Controller
    {
        //
        // GET: /Endereco/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var endereco = new Endereco();
            return View(endereco);
        }      
    }
}
