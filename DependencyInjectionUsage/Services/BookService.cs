namespace DependencyInjectionUsage.Services;

public class BookService : IBookService
{
    public string Add()
    {
        Console.WriteLine("Oracle Book Added");
        return "Success";
    }

    public string Delete()
    {
        Console.WriteLine("Oracle Book Deleted");
        return "Success";

    }

    public string Update()
    {
        Console.WriteLine("Oracle Book Updated");
        return "Success";
        
    }

    public void Refresh()
    {
        Console.WriteLine("Oracle Book Refreshed");
    }
}