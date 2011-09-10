using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models.Sevices.Interfaces;
using AutoEscola.Models.Repositories;

namespace AutoEscola.Models.Sevices
{
    public class ServicosUsuarioAluno : ValidadorServicos, IServicosUsuario
    {
        private IUsuarioRepository usuarioRepository;
        private IPessoaRepository pessoaRepository;
        private Usuario Usuario;

        private const string PERFIL_ALUNOS = "role_alunos";

        public ServicosUsuarioAluno(IUsuarioRepository usuarioRepository, IPessoaRepository pessoaRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.pessoaRepository = pessoaRepository;
        }

        private void VerificarSeEmailJaEstaCadastrado()
        {
            if (!usuarioRepository.EmailValidoParaCadastro(this.Usuario.Email))
                AdicionarErro("e-mail inválido. Tentre outro endereço");
        }

        private void ProcurarCadastroDeAlunoParaAssociarAoUsuario()
        {
            this.Usuario.Pessoa = pessoaRepository.ProcurarPessoaPorCpf(this.Usuario.Pessoa.CPF);
        }

        private void VerificarSeAlunoPodeSerAssociadaAoUsuario()
        {
            if (this.Usuario.Pessoa == null)
                AdicionarErro("Não há registro deste CPF para realização de cadastro para este usuário");

            if (pessoaRepository.ExisteUmUsuarioCadastradoParaPessoa(this.Usuario.Pessoa))
                AdicionarErro(string.Format("O proprietário do CPF '{0}' já possui um usuário associado", this.Usuario.Pessoa.CPF));
        }

        public void Desconectar()
        {
            Sessao.Sair();
        }

        public void CriarNovoUsuario(Usuario usuario)
        {
            this.Usuario = usuario;

            ApagarErros();

            ProcurarCadastroDeAlunoParaAssociarAoUsuario();
            VerificarSeAlunoPodeSerAssociadaAoUsuario();
            VerificarSeEmailJaEstaCadastrado();

            if (!PossuiErros())
                CadastrarUsuarioDoAluno();
        }

        private void CadastrarUsuarioDoAluno()
        {
            this.Usuario.GerarChaveDeAtivacao();
            usuarioRepository.Criar(this.Usuario, PERFIL_ALUNOS);
        }

        public bool Logar(string login, string senha)
        {
            if(!usuarioRepository.Validar(login, senha, PERFIL_ALUNOS))
            {
                AdicionarErro("Usuário / e-mail e senhas inválidos.");
                return false;
            }
            return true;
        }
    }
}
