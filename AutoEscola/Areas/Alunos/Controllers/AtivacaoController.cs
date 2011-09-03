using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Repository;
using AutoEscola.Repository.Factory;

namespace AutoEscola.Areas.Alunos.Controllers
{
    public class AtivacaoController : Controller
    {
        //
        // GET: /Alunos/Ativacao/

        [HandleError]
        public ActionResult Index(string chave)
        {
            var repositorio = RepositoryFactory.CreateUsuarioRepository();
            if (repositorio.Ativar(chave))
                return View();
            return RedirectToAction("Index", "HomeAlunos");
        }

    }
}
