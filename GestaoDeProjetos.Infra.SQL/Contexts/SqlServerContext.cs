using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Infra.SQL.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.SQL.Contexts
{
    public class SqlServerContext : DbContext
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="dbContextOptions">Classe do EF para opções de configuração do DbContext</param>
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        /// <summary>
        /// Método para adicionar cada classe de mapeamento
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }

        /// <summary>
        /// Propriedade para fornecer os métodos que serão
        /// utilizados no repositório de usuários
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
