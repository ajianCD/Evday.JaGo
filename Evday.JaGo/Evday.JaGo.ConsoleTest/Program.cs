using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.ReadLine();

        }


        public void Test1()
        {
            A a = new B
            {
                a = "a",
                b = "b",
                c = "c",
            };
            B c = new B
            {
                a = "a",
                b = "b",
                c = "c",
            };
            PutMethod(a);
            PutMethod<A>(c);
            PutMethod<B>(c);
            PutMethod<IC>(c);
        }

        public static void PutMethod<T>(T t)
        {

            Type type1 = typeof(T);
            Console.WriteLine();
            Console.WriteLine("****************typeof*******************************");
            foreach (var item in type1.GetProperties())
            {
                string name = item.Name;
                string value = item.GetValue(t).ToString();
                Console.WriteLine("name=" + name + ",value=" + value);
            }
            Console.WriteLine("****************GetType*******************************");
            Type type2 = t.GetType();

            foreach (var item in type2.GetProperties())
            {
                string name = item.Name;
                string value = item.GetValue(t).ToString();
                Console.WriteLine("name=" + name + ",value=" + value);
            }

        }
        public class A
        {
            public string a { get; set; }
        }
        public interface IC
        {
            string c { get; set; }
        }
        public class B : A, IC
        {
            public string c { get; set; }
            public string b { get; set; }
        }
    }
}
