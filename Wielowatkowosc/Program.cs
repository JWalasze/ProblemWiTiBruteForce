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
            List<WitiTask> list = new List<WitiTask>();
            list.Add(new WitiTask(2,3,4));
            list.Add(new WitiTask(4,3,3));
            list.Add(new WitiTask(1,4,5));
            list.Add(new WitiTask(3,2,2));

            /*List<WitiTask> list3 = list;
            WitiTask[] tab = new WitiTask[list.Count];
            list.CopyTo(tab);
            List<WitiTask> list2 = tab.ToList();*/
                
            //Console.WriteLine("czy są równe: " + Object.ReferenceEquals(list, list2));
            //Console.WriteLine("czy są równe: " + Object.ReferenceEquals(list, list3));

            FindPermutations findObj = new FindPermutations(list);
            Console.WriteLine("Zaczynamy: ");
            findObj.Permutations(list);
            Console.WriteLine(findObj.Resualt.ToString());
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
