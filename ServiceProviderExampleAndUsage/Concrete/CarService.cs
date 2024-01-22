using ServiceProviderExampleAndUsage.Abstraction;

namespace ServiceProviderExampleAndUsage.Concrete;

public class CarService : ICarService
{
    private List<Car> CarList = new List<Car>();
    public CarService(List<Car> carList)
    {
        CarList = carList;
    }
    public int GetValueByBrand(string brand)
    {
        //use database service

        var car = CarList.Select(s => s.Brand == brand ? s.Value : 0).FirstOrDefault();
        if (car == 0)
        {
            throw new Exception("There is not car");
        }
        else
        {
            return car;
        }
    }

    public string GetBrandById(Guid id)
    {
        return "";
    }
}

public class Car
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public string Brand { get; set; }
}