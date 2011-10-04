using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models.Servicos.Interfaces;
using AutoEscola.Models.Repositorios;

namespace AutoEscola.Models.Servicos
{
    public class ServicosUsuarioAdmin : ServicosUsuario, IServicosUsuarioAdmin
    {
        private IRepositorioPessoa PessoaRepository;
        private IRepositorioUsuario UsuarioRepository;
        private IRepositorioEmpresa EmpresaRepository;

        private const string PERFIL_ADMIN = "role_admin";
        private const string PERFIL_ADMIN_FREE_TOUR = "role_admin_free_tour";

        public ServicosUsuarioAdmin(IRepositorioUsuario usuarioRepository, IRepositorioPessoa pessoaRepository, IRepositorioEmpresa empresaRepository)
            :base(usuarioRepository, pessoaRepository)
        {
            this.PessoaRepository = pessoaRepository;
            this.UsuarioRepository = usuarioRepository;
            this.EmpresaRepository = empresaRepository;
        }

        private bool CnpjExisteNoCadastroDeEmpresa(string cnpj)
        {
            if (EmpresaRepository.ProcurarPorCnpj(cnpj) != null)
            {
                AdicionarErro("");
                return true;
            }
            return false;
        }

        public void CriarContaDeUsuarioSuperAdminFree(Usuario usuario)
        {
            ApagarErros();

            var empresa = usuario.Pessoa.Empresa;

            if (CnpjExisteNoCadastroDeEmpresa(empresa.CNPJ))
                AdicionarErro("CNPJ já cadastrado");

            VerificarSeEmailJaEstaCadastrado(usuario.Email);
            CriarUsuario(usuario, PERFIL_ADMIN_FREE_TOUR);                
        }

        public bool Logar(string login, string senha)
        {
            return LogarUsuario(login, senha, PERFIL_ADMIN);
        }

        public bool LogarFreeTour(string login, string senha)
        {
            return LogarUsuario(login, senha, PERFIL_ADMIN_FREE_TOUR);
        }
    }
}
