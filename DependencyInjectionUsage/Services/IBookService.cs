namespace DependencyInjectionUsage.Services;

public interface IBookService
{
    public string Add();
    public string Delete();
    public string Update();
    public void Refresh();
}