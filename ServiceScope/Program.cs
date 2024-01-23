using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<IPencilService, PencilService>();
using (var serviceProvider = services.BuildServiceProvider())
{
    //Scope oluşturmak için kullandık.
    var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
    //Bu using bloğu içerisinde kalındığı sürece IPencilService bir referans bulacak fakat using bloğu dışına çıkıldığında
    //bu service kullanılamaz hale gelecektir.
    using (var scope = scopeFactory.CreateScope())
    {
        var scopedService = scope.ServiceProvider.GetRequiredService<IPencilService>();

        scopedService.Add();
        scopedService.Delete();
    }
}

public interface IPencilService
{
    public void Add();
    public void Delete();
    
}

public class PencilService : IPencilService
{
    public void Add()
    {
        Console.WriteLine("Added");
    }

    public void Delete()
    {
        Console.WriteLine("Deleted");
    }
}