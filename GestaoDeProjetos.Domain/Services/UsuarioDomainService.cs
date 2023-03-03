using GestaoDeProjetos.Domain.Core;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Repositories;
using GestaoDeProjetos.Domain.Interfaces.Security;
using GestaoDeProjetos.Domain.Interfaces.Services;
using GestaoDeProjetos.Domain.Models;

namespace GestaoDeProjetos.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributos
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationSecurity _authorizationSecurity;

        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public UsuarioDomainService(IUnitOfWork unitOfWork, IAuthorizationSecurity authorizationSecurity)
        {
            _unitOfWork = unitOfWork;
            _authorizationSecurity = authorizationSecurity;
        }

        /// <summary>
        /// Método para criar um usuário na aplicação
        /// </summary>
        /// <param name="usuario">Entidade de domínio</param>
        public void CriarUsuario(Usuario usuario)
        {
            //Não é permitido cadastrar usuários com o mesmo email
            DomainException.When(
                    _unitOfWork.UsuarioRepository.GetByEmail(usuario.Email) != null,
                    $"O email {usuario.Email} já está cadastrado, tente outro."
                );

            _unitOfWork.UsuarioRepository.Create(usuario);
        }

        public AuthorizationModel AutenticarUsuario(string email, string senha)
        {
            //consultar o usuário no banco de dados através do email e senha
            var usuario = _unitOfWork.UsuarioRepository.GetByEmailAndSenha(email, senha);

            DomainException.When(
                usuario == null,
                "Acesso negado. Usuário não encontrado."
                );

            return new AuthorizationModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                AccessToken = _authorizationSecurity.CreateToken(usuario)
            };
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
