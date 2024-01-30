using ApiAgenda.CrossCutting;
using ApiAgenda.Data.Context;
using ApiAgenda.Domain.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connection = builder.Configuration.GetConnectionString("PostgreServer");
        var postgresVersion = builder.Configuration.GetValue<string>("postgresVersion");

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Agenda", Version = "v1",
                    Description = "<h3>API para Agenda</h3><h4><b>Retornos:</b></h4>\n<h4>2xx - Sucesso</h4>\n<li>200 Ok - Padrão que representa sucesso</li>\n<li>201 Created - Indica que um recurso foi criado.</li>\n<li>202 Accepted - Indica que o servidor aceitou a request e irá processar assíncronamente</li>\n<li>204 No Content - Representa que a request foi processada com sucesso, mas não há conteúdo para ser retornado</li>\n<h4>4xx - Client error</h4>\n<li>400 Bad Request - A solicitação não foi processada, pois o servidor não entendeu o que o cliente está solicitando</li>\n<li>401 Unauthorized - Indica que o client não está autenticado e não tem autorização para acessar o recurso</li>\n<li>403 Forbidden - Indica que o Client está autenticado e a requisição é válida. Porém o client não tem permissão de acesso naquele recurso</li>\n<li>404 Not Found - indica que o recurso não foi localizado</li>\n<h4>5xx - Erros no servidor</h4>\n<li>500 Internal Server Error - O servidor encontrou uma situação com a qual não sabe lidar</li>\n<li>501 Not Implemented - O método da requisição não é suportado pelo servidor e não pode ser manipulado</li>\n<li>503 Service Unavailable - O servidor não está pronto para manipular a requisição</li>\n\n<h4><b>Autorização:</b></h4><p>Crie sua autenticação através de seu Token, utilizando seu Documento e Nome. Após receber sua resposta solicite a autorização de uso da plataforma informando o Jwt Bearer que foi recebido na mesma. Esta autorização é válida por um determinado tempo, que é informado também na resposta da autenticação.</p>",
                    Contact = new OpenApiContact
                    {
                        Name = "Nome contato", Email = "suporte@seuprovedor.com", Url = new Uri("https://seudominio.com/")
                    }
                });
        });

        DependencyInjector.RegisterServices(builder.Services);

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Services.AddDbContext<AgendaContext>(options =>
            options.UseNpgsql(connection, optionsAction => optionsAction.SetPostgresVersion(new Version(postgresVersion ?? throw new InvalidOperationException()))));

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiAgenda v1");
        });

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}