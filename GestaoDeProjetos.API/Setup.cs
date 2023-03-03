using GestaoDeProjetos.Application.Interfaces;
using GestaoDeProjetos.Application.Services;
using GestaoDeProjetos.Domain.Interfaces.Repositories;
using GestaoDeProjetos.Domain.Interfaces.Security;
using GestaoDeProjetos.Domain.Interfaces.Services;
using GestaoDeProjetos.Domain.Services;
using GestaoDeProjetos.Infra.Messages.Helpers;
using GestaoDeProjetos.Infra.Messages.Producers;
using GestaoDeProjetos.Infra.Messages.Settings;
using GestaoDeProjetos.Infra.Mongo.Context;
using GestaoDeProjetos.Infra.Mongo.Interfaces;
using GestaoDeProjetos.Infra.Mongo.Persistence;
using GestaoDeProjetos.Infra.Mongo.Settings;
using GestaoDeProjetos.Infra.Security.Services;
using GestaoDeProjetos.Infra.Security.Settings;
using GestaoDeProjetos.Infra.SQL.Contexts;
using GestaoDeProjetos.Infra.SQL.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GestaoDeProjetos.API
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            builder.Services.AddTransient<IProjetoAppService, ProjetoAppService>();
            builder.Services.AddTransient<ITarefaAppService, TarefaAppService>();
            builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            builder.Services.AddTransient<IProjetoDomainService, ProjetoDomainService>();
            builder.Services.AddTransient<ITarefaDomainService, TarefaDomainService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("GestaoDeProjetos");
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddMediatRServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Gestão de Projetos",
                    Description = "API REST Gestão de tarefas de Projetos",
                    Contact = new OpenApiContact { Name = "TheONe Software", Email = "contato@theonesoftware.com.br", Url = new Uri("http://www.theonesoftware.com.br") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                   s => s.AddPolicy("DefaultPolicy", builder =>
                   {
                       builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                              .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
                              .AllowAnyHeader(); //qualquer informação de cabeçalho
                   })
               );
        }

        public static void UseCors(this WebApplication app)
        {
            app.UseCors("DefaultPolicy");
        }

        public static void AddMessageServices(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MessageSettings>(builder.Configuration.GetSection("MessageSettings"));
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

            builder.Services.AddTransient<MessageQueueProducer>();
            builder.Services.AddTransient<MailHelper>();
        }
        public static void AddMongoDBServices(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

            builder.Services.AddSingleton<MongoDBContext>();
            builder.Services.AddTransient<ILogUsuariosPersistence, LogUsuariosPersistence>();
        }
        public static void AddJwtBearerSecurity(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddTransient<IAuthorizationSecurity, AuthorizationSecurity>();

            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes
                                (builder.Configuration.GetSection("JwtSettings").GetSection("SecretKey").Value)
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
        }

    }
}
