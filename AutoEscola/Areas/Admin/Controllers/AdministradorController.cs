using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models.Repositorios;
using AutoEscola.Models.Servicos.Interfaces;
using AutoEscola.Models;
using AutoEscola.Models.Servicos;

namespace AutoEscola.Areas.Admin.Controllers
{
    public class AdministradorController : Controller
    {
        private IServicosUsuarioAdmin ServicosUsuarioSuperAdmin;

        public AdministradorController(IServicosUsuarioAdmin servicosUsuarioSuperAdmin)
        {
            this.ServicosUsuarioSuperAdmin = servicosUsuarioSuperAdmin;
        }
                
        public ActionResult CadastrarEmpresa()
        {
            Usuario usuario = new Usuario();
            usuario.Pessoa = new Pessoa();
            usuario.Pessoa.Empresa = new Empresa();

            return View(usuario);
        }

        [HttpPost]
        public ActionResult CadastrarEmpresa(Usuario usuario)
        {
            ServicosUsuarioSuperAdmin.CriarContaDeUsuarioSuperAdminFree(usuario);

            return View();
        }

    }
}
