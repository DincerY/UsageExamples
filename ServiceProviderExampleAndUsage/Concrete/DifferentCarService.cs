using ServiceProviderExampleAndUsage.Abstraction;

namespace ServiceProviderExampleAndUsage.Concrete;

/// <summary>
/// Bu classı aynı interfaceden türeyen ve farklı yaklaşım içeren bir class olarak oluşturdum.
/// Bu iki classı iki farklı teknolojiye benzetebiliriz ve biz şuan CarService teknolojisini kullanıyoruz.
/// Bu ileride değişebilir ve bunun farkındalığında kodlama yapmalıyız DifferentCarService ise farklı ve yeni bir teknoloji olsun.
/// Biz uygulamaızda ki eski teknolojiyi yenisi ile değiştirmek istiyoruz tutupta bütün kodları bütün bağımlılıkları
/// yeniden yazmaktansa Dependency Injection yardımıyla aynı interfaceden türeyen birden classların bağımlılığını
/// azaltabiliriz. Yani bu iki teknolojide ICarService den imza alıyor ve ICarService her ikisininde referansını tutabilir.
/// Yani bizim kullacağımız teknoloji referansına bağımlılıktan ziyade bir interface ile iki farklı yada daha fazla teknolonin
/// referansını tuttuk.
/// </summary>
public class DifferentCarService : ICarService
{
    
    public int GetValueByBrand(string brand)
    {
        return 1000;
    }

    public string GetBrandById(Guid id)
    {
        throw new NotImplementedException();
    }
    
}