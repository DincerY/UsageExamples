// See https://aka.ms/new-console-template for more information

Urun ciklet = new Urun(10001, "Tipitipitip", 1.20, 35);
ciklet.StokAzaldi += ciklet_StokAzaldi;

for (int i = 0; i <5; i++)
{
    ciklet.StokMiktari -= 7;
    Thread.Sleep(600);
    Console.WriteLine(ciklet.Ad + " için stok miktarı " + ciklet.StokMiktari.ToString());
}

static void ciklet_StokAzaldi()
{
    Console.WriteLine("Stok miktarı 10 değerinin altında...Alarrrmmm!");
}

delegate void StokAzaldiEventHandler();
 
class Urun
{
    private int id;
    private string ad;
    private double birimFiyat;
    private int stokMiktari;
 
    public event StokAzaldiEventHandler StokAzaldi;
     
    public int StokMiktari
    {
        get { return stokMiktari; }
        set {
            stokMiktari = value; 
            if (value < 10 && StokAzaldi != null)
                StokAzaldi(); 
        }
    }
 
    public double BirimFiyat
    {
        get { return birimFiyat; }
        set { birimFiyat = value; }
    }
 
    public string Ad
    {
        get { return ad; }
        set { ad = value; }
    }
 
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
 
    public Urun(int idsi, string adi, double fiyati, int stokSayisi)
    {
        Id = idsi;
        Ad = adi;
        BirimFiyat = fiyati;
        StokMiktari = stokSayisi;
    }
}
//Event Argument
class StokAzaldiEventArgs:EventArgs
{
    private int guncelStokMiktari;
 
    public int GuncelStokMiktari
    {
        get { return guncelStokMiktari; }
        set { guncelStokMiktari = value; }
    }
    public StokAzaldiEventArgs(int gStk)
    {
        GuncelStokMiktari = gStk;
    }
}