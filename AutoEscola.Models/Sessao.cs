using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace AutoEscola.Models
{
    public static class Sessao
    {
        public static Usuario Usuario
        {
            get
            {
                return (Usuario)HttpContext.Current.Session["usuaro_sessao"];
            }
            set
            {
                HttpContext.Current.Session["usuaro_sessao"] = value;
            }

        }

        public static void Sair()
        {
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();
        }

        public static void Iniciar(Usuario usuario)
        {
            FormsAuthentication.SetAuthCookie(usuario.Email, false);
            FormsAuthentication.Authenticate(usuario.Email, usuario.Senha);
            Sessao.Usuario = usuario;
        }
    }
}
