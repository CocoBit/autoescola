using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoEscola.Models;

namespace AutoEscola.Controllers
{
    public class OcorrenciaController : Controller
    {
        //
        // GET: /Ocorrencia/

        public ActionResult Index(List<Ocorrencia> ocorrencias)
        {
            return View(ocorrencias);
        }
    }
}
