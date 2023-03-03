using FluentValidation.Results;

namespace GestaoDeProjetos.Domain.Core
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
        ValidationResult Validate { get; }
    }
}