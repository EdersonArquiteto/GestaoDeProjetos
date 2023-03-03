using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Repositories;
using GestaoDeProjetos.Infra.SQL.Contexts;
using GestaoDeProjetos.Infra.SQL.Helpers;

namespace GestaoDeProjetos.Infra.SQL.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, Guid>, IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public UsuarioRepository(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public override void Create(Usuario entity)
        {
            entity.Senha = MD5Helper.Encrypt(entity.Senha);
            base.Create(entity);
        }

        public override void Update(Usuario entity)
        {
            entity.Senha = MD5Helper.Encrypt(entity.Senha);
            base.Update(entity);
        }

        public Usuario GetByEmail(string email)
        {
            return _sqlServerContext.Usuario
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            senha = MD5Helper.Encrypt(senha);

            return _sqlServerContext.Usuario
                .FirstOrDefault(u => u.Email.Equals(email)
                                  && u.Senha.Equals(senha));
        }
    }
}
