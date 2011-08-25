using System.Linq;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Contexts.Models;
using AutoEscola.Models;
using System.Web.Security;

namespace AutoEscola.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AutoEscolaContext _context;

        public UsuarioRepository(AutoEscolaContext context)
        {
            _context = context;
        }

        public void Criar(Usuario usuario, string perfil)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            RegistrarUsuarioAoPerfilDeAcesso(usuario, perfil);
        }

        public bool Validar(string login, string password, string perfil)
        {
            var usuario = BuscarUsuariosPorLoginSenha(login, password);

            if (!UsuarioValidoParaSessao(usuario, perfil))
                return false;

            Sessao.Iniciar(usuario);

            return true;
        }

        private bool UsuarioValidoParaSessao(Usuario usuario, string perfil)
        {
            return ((usuario != null) && (UsuarioEstaRegistradoAoPerfil(usuario, perfil)));
        }

        private Usuario BuscarUsuariosPorLoginSenha(string login, string password)
        {
            var usuarios = _context.Usuarios.Where(u => u.Login == login || u.Email == login);

            return usuarios.Count() == 0 ? null : usuarios.First();
        }

        public bool EmailValidoParaCadastro(string email)
        {
            var usuarios = _context.Usuarios.Where(u => u.Email == email);
            return usuarios.Count() <= 0;
        }

        private static void CriarPerfilDeAcessoCasoEleNaoExista(string perfil)
        {
            if (!Roles.RoleExists(perfil))
                Roles.CreateRole(perfil);
        }

        private static void RegistrarUsuarioAoPerfilDeAcesso(Usuario usuario, string perfil)
        {
            CriarPerfilDeAcessoCasoEleNaoExista(perfil);

            if (!UsuarioEstaRegistradoAoPerfil(usuario, perfil))
                Roles.AddUserToRole(usuario.Email, perfil);
        }

        private static bool UsuarioEstaRegistradoAoPerfil(Usuario usuario, string perfil)
        {
            return Roles.IsUserInRole(usuario.Email, perfil);
        }
    }
}
