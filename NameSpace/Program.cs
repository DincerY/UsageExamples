// See https://aka.ms/new-console-template for more information
using System;
using NameSpace.Deneme;


namespace NameSpace
{
    namespace AnotherNameSpace
    {
        public class MyDenemeClass
        {
            public int DenemeVeri { get; set; }
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            CustomClass customClass = new();
        }
    }


    //Class
    public class MyClass
    {
        public MyClass()
        {
            Veri = 10;
        }

        public int Veri { get;}
    }
    
    //Struct
    public struct MyStruct
    {
        
    }
    //Interface
    public interface IMyInterface
    {
        
    }
    //Enum
    public enum MyEnum{
    
    }
    
    //Delegate
    /// <summary>
    /// Remarks
    /// </summary>
    public delegate void MyDelegate(string a);
}


