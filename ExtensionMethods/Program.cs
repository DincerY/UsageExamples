// See https://aka.ms/new-console-template for more information

//Extension method aslında var olan kütüphane içine bir kod yazmaktansa onu genişletip sanki istediğimiz kod kütüphanedeki
//classın içinde zaten varmış gibi kullanmamızı sağlar.
Console.WriteLine("Hello, World!");
string deneme = "asd";
string result = deneme.UppercaseFirstLetter();

//Boş systems class ı görüldüğü üzere extend edilerek MyExtensionMethod isimli methodu çağırabildi.
Systems systems = new Systems();
var a =systems.MyExtensionMethod();
Console.WriteLine(a);


public static class StringExtensions
{
    public static string UppercaseFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }
}

//System class ı gibi düşünülebilir
public class Systems
{
    
}

public static class ExtensionClass
{
    public static int MyExtensionMethod(this Systems systems)
    {
        return 10;
    }
}





