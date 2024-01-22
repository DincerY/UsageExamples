namespace ServiceProviderExampleAndUsage.Abstraction;

public interface ICarService
{
    public int GetValueByBrand(string brand);   
    public string GetBrandById(Guid id);
    
}