// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

void Deneme(object? obj,string argument)
{
    Console.WriteLine("Deneme");
}
void Deneme2(object? obj,string argument)
{
    Console.WriteLine("Deneme2");
}
void Deneme3(object? obj,string argument)
{
    Console.WriteLine("Deneme3");
}
void Deneme4(object? obj,string argument)
{
    Console.WriteLine("Deneme4");
}

object a = null;





EventHandler<string> eventHandler = new(Deneme);
eventHandler+=Deneme2;
eventHandler+=Deneme3;
eventHandler+=Deneme4;


eventHandler.Invoke(a,"123");