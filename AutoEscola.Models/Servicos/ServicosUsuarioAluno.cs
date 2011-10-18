using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models.Repositorios;
using AutoEscola.Models.Servicos;
using AutoEscola.Models.Servicos.Interfaces;

namespace AutoEscola.Models.Servicos
{
    public class ServicosUsuarioAluno : ServicosUsuario, IServicosUsuarioAluno
    {
        private IRepositorioUsuario usuarioRepository;
        private IRepositorioPessoa pessoaRepository;

        private const string PERFIL = "role_alunos";

        public ServicosUsuarioAluno(IRepositorioUsuario usuarioRepository, IRepositorioPessoa pessoaRepository)
            : base(usuarioRepository, pessoaRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.pessoaRepository = pessoaRepository;
        }


        private void VerificarSeAlunoPodeSerAssociadaAoUsuario(Usuario usuario)
        {
            ApagarErros();

            if (string.IsNullOrEmpty(usuario.Pessoa.CPF))
                AdicionarErro("CPF inválido para realização de cadastro para este usuário");

            var pessoa = ProcurarCadastroDeAlunoParaAssociarAoUsuario(usuario.Pessoa.CPF);

            if (pessoa == null)
                AdicionarErro("Não há registro deste CPF para realização de cadastro para este usuário");

            if (PessoaJaPossuiUsuario(pessoa))
                AdicionarErro(string.Format("O proprietário do CPF '{0}' já possui um usuário associado", pessoa.CPF));

            VerificarSeEmailJaEstaCadastrado(usuario.Email);

            usuario.Pessoa = pessoa;
        }

        public void CriarContaDeUsuarioAluno(Usuario usuario)
        {
            VerificarSeAlunoPodeSerAssociadaAoUsuario(usuario);
            CriarUsuario(usuario, PERFIL);
        }

        public bool Logar(string login, string senha)
        {
            return LogarUsuario(login, senha, PERFIL);
        }
    }
}
