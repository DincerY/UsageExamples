DerivedClass derivedClass = new();
derivedClass.Print("Hello");
derivedClass.PrintVirtual("Hello");



public class BaseClass
{
    public void Print(string a)
    {
        Console.WriteLine($"{a}");
    }

    public virtual void PrintVirtual(string a)
    {
        Console.WriteLine($"{a}");
    }
}

public class DerivedClass : BaseClass
{
    public override void PrintVirtual(string a)
    {
        Console.WriteLine($"DerivedClass Method {a}");
    }
}

public abstract class MyAbstractClass
{
    public void MyMethod()
    {
        
    }

    public abstract void MyAbstractMethod();
}

public class MyClass : MyAbstractClass
{
    //Sadece abstract olan member override edildi.
    //Virtual keyword ile karıştırılmasın abstract memberlar sadece abstract classlar içinde yazırlır ve 
    //abstract olan memberlar hiç bir şekilde base classta doldurulamaz
    //Ancak bir virtual member base classta da doldurulup istenirse eğer derived classta da doldurulabilir.
    //Tabi ki derived class kullanılıyorsa ve virtual member ezilip yeni hali doldurulmuşsa, yeni hali kullanılır.
    public override void MyAbstractMethod()
    {
        throw new NotImplementedException();
    }
    
}