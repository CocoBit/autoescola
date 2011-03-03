using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;

namespace AutoEscola.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create(Empresa empresa)
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

    }
}
