using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Repository;
using AutoEscola.Models.Repositorios;

namespace AutoEscola.Controllers
{
    public class ContaController : Controller
    {
        //
        // GET: /Alunos/Ativacao/

        private IRepositorioUsuario usuarioRepositorio;

        public ContaController(IRepositorioUsuario usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        [HandleError]
        public ActionResult Index(string chave)
        {
            if (this.usuarioRepositorio.Ativar(chave))
                return View();
            return RedirectToAction("Index", "HomeAlunos");
        }

        public ActionResult Confirmar()
        {
            return View();
        }

    }
}
