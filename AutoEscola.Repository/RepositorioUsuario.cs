using System.Linq;
using AutoEscola.Contexts.Models;
using AutoEscola.Models;
using System.Web.Security;
using System;
using AutoEscola.Models.Repositorios;

namespace AutoEscola.Repository
{
    public class RepositorioUsuario : IRepositorioUsuario, IDisposable
    {
        private AutoEscolaContext BancoDeDados;

        public RepositorioUsuario(AutoEscolaContext context)
        {
            BancoDeDados = context;
        }

        public void Criar(Usuario usuario, string perfil)
        {
            try
            {
                BancoDeDados.Usuarios.Add(usuario);
                BancoDeDados.SaveChanges();
                RegistrarUsuarioAoPerfilDeAcesso(usuario, perfil);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar criar conta de usuário", ex);
            }
        }

        public bool Validar(string login, string password, string perfil)
        {
            try
            {
                var usuario = BuscarUsuariosPorLoginSenha(login, password);
                if (!UsuarioValidoParaSessao(usuario, perfil))
                    return false;

                Sessao.Iniciar(usuario);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar validar usuário", ex);
            }
        }

        public bool Ativar(string chave)
        {
            try
            {
                var usuarios = from u in BancoDeDados.Usuarios
                               where u.CodigoAtivacao == chave
                               select u;

                if (usuarios.Count() > 0)
                {
                    Usuario usuario = usuarios.First();
                    usuario.CodigoAtivacao = "";
                    usuario.SenhaConfirmacao = usuario.Senha;
                    BancoDeDados.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private bool UsuarioValidoParaSessao(Usuario usuario, string perfil)
        {
            return ((usuario != null) && (UsuarioEstaRegistradoAoPerfil(usuario, perfil)));
        }

        private Usuario BuscarUsuariosPorLoginSenha(string login, string password)
        {
            var usuarios = from u in BancoDeDados.Usuarios
                           where (u.Login == login || u.Email == login) &&
                           u.Senha == password &&
                           string.IsNullOrEmpty(u.CodigoAtivacao)
                           select u;

            return usuarios.Count() == 0 ? null : usuarios.First();
        }

        public bool EmailValidoParaCadastro(string email)
        {
            var usuarios = BancoDeDados.Usuarios.Where(u => u.Email == email);
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

        public void Dispose()
        {
            BancoDeDados.Dispose();
        }
    }
}
