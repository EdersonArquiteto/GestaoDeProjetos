﻿namespace GestaoDeProjetos.Domain.Models
{
    public class AuthorizationModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public string? AccessToken { get; set; }
    }
}
