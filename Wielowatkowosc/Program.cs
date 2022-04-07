using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadsAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int n = 10;
            Test t = new Test();
            Thread[] threads = new Thread[n];
            for (int i = 0; i < n; i++)
            {
                threads[i] = new Thread(t.Welcome);
                threads[i].Name = String.Format("Thread: {0}", i);
            }
            foreach (Thread x in threads)
                x.Start();
            Console.Read();*/
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(6); /*
            Console.WriteLine(list[0] + ", " + list[1] + ", " + list[2] + ", " + list[3]);
            list.Swap(0, 3);
            Console.WriteLine(list[0] + ", " + list[1] + ", " + list[2] + ", " + list[3]);
            list.Swap(0, 3);
            Console.WriteLine(list[0] + ", " + list[1] + ", " + list[2] + ", " + list[3]);
            Console.Read();*/
            FindPermutations findObj = new FindPermutations(4);
            Console.WriteLine("Zaczynamy: ");
            findObj.Permutations(list, 0, 10);
            Console.WriteLine("Kończymy!!!");
            Console.ReadLine();
        }
        public class Test
        {
            public void Welcome()
            {
                lock (this)
                {
                    Console.WriteLine("Hallo " + Thread.CurrentThread.Name + "!");
                    for (int i = 0; i < 10; i++)
                        Console.Write(i + " ");
                    Console.WriteLine("");
                }
            }
        }
    }
}
