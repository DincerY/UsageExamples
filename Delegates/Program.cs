// See https://aka.ms/new-console-template for more information
FuncDelegate funcDelegate = new();
#region FuncDelegate
public class FuncDelegate
{
    private delegate void MyDelegate(int a);

    private delegate TH MyFunc<in T, out TH>(T TDeneme);

    private delegate void GenericDelegate<T>(T TDeneme);

    public int DelegatedMethod<T>(T a)
    {
        return 0;
    }

    private void DelegatedMethodDifferent<T>(T a)
    {
        return;
    }

    //Generic olan delegateler hazır delegateler olduğundan new operatörüne ihtiyaç duymazlar.
    public void AddMethod()
    {
        MyFunc<int, int> myFunc = DelegatedMethod;
        GenericDelegate<int> genericDelegate = DelegatedMethodDifferent;
    }

}

#endregion



#region Kullanimi

void Yazdir(int sayi,int sayi2)
{
    Console.WriteLine("Deneme metodu çalıştı");
    Console.WriteLine("{0}--{1}",sayi,sayi2);
}
void Topla(int sayi,int sayi2)
{
    Console.WriteLine("Deneme metodu çalıştı");
    Console.WriteLine($"Toplam sonucu : {sayi+sayi2}");
}

MyDelegateHandler yazdirHandler = new MyDelegateHandler(Yazdir);
MyDelegateHandler yazdirHandler2 = Yazdir;
MyDelegateHandler toplaHandler = new MyDelegateHandler(Topla);

//iki şekilde fonksiyonu tetikleyebiliyorum.
yazdirHandler(10,20);
yazdirHandler.Invoke(30, 40);
//bir delegate ile farklı işlem yapan methodu tutabiliriz
toplaHandler(10, 20);
toplaHandler.Invoke(30,40);

#endregion

#region Delegate e Birden Fazla Method Ekleme

void Method1(int a)
{
    Console.WriteLine(a);
}
void Method2(int a)
{
    Console.WriteLine(a*a);
}
void Method3(int a)
{
    Console.WriteLine(a*a*a);
}

ThreeMethodDelegate threeMethodDelegate = new(Method1);
threeMethodDelegate += Method2;
threeMethodDelegate += Method3;

threeMethodDelegate(2);

threeMethodDelegate -= Method3;
Console.WriteLine("Method3 Cikarildi");
threeMethodDelegate(2);

threeMethodDelegate -= Method2;
Console.WriteLine("Method2 Cikarildi");
threeMethodDelegate(2);

threeMethodDelegate += Method2;
Console.WriteLine("Method2 eklendi");
threeMethodDelegate(2);


#endregion

#region EventHandler
EventHandler eventHandler = new(DoIt);

EventHandler<string> stringEventHandler = new(DoItString);


void DoIt(object? obj,EventArgs a)
{
        
}

void DoItString(object? obj,string a)
{
    
}

#endregion

/// <summary>
/// Sıradan bir delegate
/// </summary>
public delegate void MyDelegateHandler(int a, int b);

/// <summary>
/// Bu delegate 3 farklı method u tutacak
/// </summary>
public delegate void ThreeMethodDelegate(int a);