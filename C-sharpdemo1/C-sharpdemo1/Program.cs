/*class Demo
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int a = 0, b = 1;
        if (n == 0)
        {
            Console.Write("");
        }
        else if (n == 1)
        {
            Console.Write(a);
        }
        else if (n == 2)
        {
            Console.Write(a + " " + b);
        }
        else
        {
            Console.Write("0 1 ");
            for (int i = 0; i < n - 2; i++)
            {
                int sum = a + b;
                Console.Write(sum + " ");
                a = b;
                b = sum;
            }
        }
    }
}*/


/*using first;
using second;
namespace first
{
    public class Hello
    {
        public void show()
        {
            Console.WriteLine("first hello");
        }
    }
}

namespace second
{
    public class Hello
    {
        public void show()
        {
            Console.WriteLine("first hello");
        }
    }
}
namespace third
{
    class demo
    {
        public static void Main(string[] args)
        {
            Hello hel = new Hello();
        }
    }
}   */


using System;
/*namespace AccessSpecifiers
{
    class InternalTest
    {
        protected internal string name = "Shantosh Kumar";
        protected internal void Msg(string msg)
        {
            Console.WriteLine("Hello " + msg);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InternalTest internalTest = new InternalTest();
            // Accessing protected internal variable  
            Console.WriteLine("Hello " + internalTest.name);
            // Accessing protected internal function  
            internalTest.Msg("Peter Decosta");
        }
    }
}*/

/*public class ExExample
{
    public static void Main(string[] args)
    {
        try
        {
            int a = 10;
            int b = 0;
            int x = a / b;
        }
        catch (NullReferenceException e) { Console.WriteLine(e); }
        finally { Console.WriteLine("Finally block is executed"); }
        Console.WriteLine("Rest of the code");
    }
}*/


class Program
{
    public static void Main(string[] args)
    {
        Console.Write("hello world!!");
    }
}