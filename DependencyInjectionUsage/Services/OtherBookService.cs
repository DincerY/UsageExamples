namespace DependencyInjectionUsage.Services;

public class OtherBookService : IBookService
{
    public string Add()
    {
        Console.WriteLine("MySql Book Added");
        return "Success";
    }

    public string Delete()
    {
        Console.WriteLine("MySql Book Deleted");
        return "Success";

    }

    public string Update()
    {
        Console.WriteLine("MySql Book Updated");
        return "Success";
        
    }

    public void Refresh()
    {
        Console.WriteLine("MySql Book Refreshed");
    }
}