using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoEscola.Areas.Alunos.Controllers
{
    public class HomeAlunosController : Controller
    {
        //
        // GET: /Alunos/HomeAlunos/

        public ActionResult Index()
        {
            return View();
        }

    }
}
