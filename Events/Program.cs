
MyApplication application = new(10);
application.MyDelegateHandler += EsikAsimi;
Console.WriteLine("ekleme yapmak icin a ya basin");
while (Console.ReadKey(true).KeyChar == 'a')
{
   application.Add();
   Console.WriteLine("Bir adet urun eklendi");
}

//Bu metod aslında abone olunan sınıf içerisinde bulunan ve bir ==>
//olay meydana geldiğinde ne yapılacağını bildiğimiz method
static void EsikAsimi(object sender,EsikAsimiEventArgs args)
{
    Console.WriteLine($"Esik asim sayisi : {args.Sayi}");
}

/// <summary>
/// Bu delegate bizim olayımızın hangi metodu çalıştıracağını bilmek için kullanacağı bir temsilci
/// </summary>
public delegate void MyDelegateHandler(object sender,EsikAsimiEventArgs e);
/// <summary>
/// Bu sınıf benim olayımın sahibi olan yani bir nevi publisher sınıfım
/// </summary>
public class MyApplication
{
    /// <summary>
    /// Field tanımlamaları
    /// </summary>
    private int sayi;
    private int esik;

    public MyApplication(int a)
    {
        esik = a;
    }
    /// <summary>
    /// Klavyeden girilen değer a olduğunda ekleme yapacak ve sayi değeri esik değerini geçerse event çağırılacaktır.
    /// </summary>
    public void Add()
    {
        sayi++;
        if (sayi > esik)
        {
            EsikAsimiEventArgs args = new EsikAsimiEventArgs(sayi);
            EsikAsimiOldugunda(this,args);
        }
    }

    /// <summary>
    /// Herhangi bir eşik aşımı meydana geldiğinde eventi tetikleyen yani hangi metodu tutuyorsak onu çalıştıran yapı
    /// Bu örnek için başta tanımlanan EsikAsimş adlı metod.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void EsikAsimiOldugunda(object sender,EsikAsimiEventArgs args)
    {
        MyDelegateHandler.Invoke(sender,args);
    }

    /// <summary>
    /// Buda bizim eventimiz. MyDelegateHandler yapısının aslında bir delegate olduğunu unutmayalım.
    /// </summary>
    public event MyDelegateHandler MyDelegateHandler;


}

/// <summary>
/// Bu sınıfta event içinden taşınacak verileri belirlediğimiz bir sınıf
/// </summary>
public class EsikAsimiEventArgs : EventArgs
{
    private int sayi;

    public int Sayi
    {
        get
        {
            return sayi;
        }
        set
        {
            sayi = value;
        }
    }

    public EsikAsimiEventArgs(int sayi)
    {
        Sayi = sayi;
    }
}
