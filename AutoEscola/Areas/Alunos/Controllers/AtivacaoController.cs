using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Repository;
using AutoEscola.Models.Repositories;

namespace AutoEscola.Areas.Alunos.Controllers
{
    public class AtivacaoController : Controller
    {
        //
        // GET: /Alunos/Ativacao/

        private IUsuarioRepository usuarioRepositorio;

        public AtivacaoController(IUsuarioRepository usuarioRepositorio)
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

        public ActionResult ConfirmarCadastro()
        {
            return View();
        }

    }
}
