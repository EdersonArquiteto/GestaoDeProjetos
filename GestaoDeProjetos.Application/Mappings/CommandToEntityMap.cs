using AutoMapper;
using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Application.Mappings
{
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap()
        {
            CreateMap<CriarUsuarioCommand, Usuario>()
                .AfterMap((command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.DataHoraCriacao = DateTime.Now;
                });

            CreateMap<CriarProjetoCommand, Projeto>()
                .AfterMap((command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.DataHoraCriacao = DateTime.Now;
                });

            CreateMap<CriarTarefaCommand, Tarefa>()
                .AfterMap((command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.DataHoraCriacao = DateTime.Now;
                    
                });

            CreateMap<Projeto, ListarProjetoQuery>();

            
        }
    }
}
