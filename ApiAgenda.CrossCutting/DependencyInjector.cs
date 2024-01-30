using ApiAgenda.Data.Context;
using ApiAgenda.Data.Repository;
using ApiAgenda.Domain.Interfaces.Repository;
using ApiAgenda.Domain.Interfaces.Service;
using ApiAgenda.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAgenda.CrossCutting;

public class DependencyInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        AddServices(services);
        AddRepositories(services);
        AddContext(services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IAgendaService, AgendaService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IAgendaRepository, AgendaRepository>();
    }

    private static void AddContext(IServiceCollection services)
    {
        services.AddScoped<AgendaContext>();
    }
}