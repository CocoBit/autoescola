using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models.Repositorios;

namespace AutoEscola.Models.Servicos
{
    public class ServicosUsuario : ServicosValidacao
    {
        private IRepositorioUsuario UsuarioRepository;
        private IRepositorioPessoa PessoaRepository;

        public ServicosUsuario(IRepositorioUsuario usuarioRepository, IRepositorioPessoa pessoaRepository)
        {
            this.UsuarioRepository = usuarioRepository;
            this.PessoaRepository = pessoaRepository;
        }

        public void VerificarSeEmailJaEstaCadastrado(string email)
        {
            if (!UsuarioRepository.EmailValidoParaCadastro(email))
                AdicionarErro("e-mail inválido. Tentre outro endereço");
        }

        public void Desconectar()
        {
            Sessao.Sair();
        }

        protected bool LogarUsuario(string login, string senha, string perfil)
        {
            ApagarErros();
            if (!UsuarioRepository.Validar(login, senha, perfil))
            {
                AdicionarErro("Usuário / e-mail e senhas inválidos.");
                return false;
            }
            return true;
        }

        protected void CriarUsuario(Usuario usuario, string perfil)
        {
            if (!ExisteErros())
            {
                usuario.GerarChaveDeAtivacao();
                this.UsuarioRepository.Criar(usuario, perfil);
            }
        }

        protected bool PessoaJaPossuiUsuario(Pessoa pessoa)
        {
            return PessoaRepository.PessoaPossuiUmUsuarioCadastrado(pessoa);
        }

        protected Pessoa ProcurarCadastroDeAlunoParaAssociarAoUsuario(string cpf)
        {
            return PessoaRepository.ProcurarPessoaPorCpf(cpf);
        }
    }
}
