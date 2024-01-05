//Bu şekilde kullanılırsa proje içinde tekrar tekrar belirtmek zorunda kalmayız
using NameSpace;
using NameSpace.AnotherNameSpace;

//Bu şekilde kullanılırsa hangi namespace içinde olduğunu yazıp noktayla istenilen yapıya ulaşırız.
NameSpace.MyClass myClass = new();
NameSpace.AnotherNameSpace.MyDenemeClass myDenemeClass = new NameSpace.AnotherNameSpace.MyDenemeClass();


Console.WriteLine("Hello, World!");