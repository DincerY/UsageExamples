// See https://aka.ms/new-console-template for more information
MyClass myClass = new();
myClass.Id = 1;
myClass.Name = "1";

MyClass myClass2 = new();
myClass2.Id = 1;
myClass2.Name = "1";

//--------------------------------
MyRecord myRecord = new();
myRecord.Id = 10;
myRecord.Name = "10";

MyRecord myRecord2 = new();
myRecord2.Id = 10;
myRecord2.Name = "10";


Console.Write("Class : ");
Console.WriteLine(myClass.Equals(myClass2) ? "true" : "false");

Console.Write("Record : ");
Console.WriteLine(myRecord.Equals(myRecord2) ? "true" : "false");

Console.WriteLine("Hello, World!");


public class MyClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public record MyRecord
{
    public int Id { get; set; }
    public string Name { get; set; }
}

