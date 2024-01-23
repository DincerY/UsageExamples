using DependencyInjectionUsage.Services;

namespace DependencyInjectionUsage.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddMyService(this IServiceCollection services)
    {
        services.AddSingleton<IBookService, OtherBookService>();

        return services;
    }   
    
    
}