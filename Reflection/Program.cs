using System.Reflection;

Assembly assembly = typeof(Example).Assembly;

Console.WriteLine(assembly.FullName);
AssemblyName assemblyName = assembly.GetName();


public class Example
{
    private int factor;

    public Example(int fac)
    {
        factor = fac;
    }

    public int SampleMethod(int x)
    {
        Console.WriteLine("\nExample.SampleMethod({0}) executes.", x);
        return x * factor;
    }
}
