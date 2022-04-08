﻿using System;
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
            int n = 4;
            List<WitiTask> list = new List<WitiTask>();
            list.Add(new WitiTask(2, 3, 4));
            list.Add(new WitiTask(4, 3, 3));
            list.Add(new WitiTask(1, 4, 5));
            list.Add(new WitiTask(3, 2, 2));
            list.Add(new WitiTask(4, 1, 1));
            list.Add(new WitiTask(5, 2, 3));
            FindPermutations findObj = new FindPermutations(list);

            WitiTask[] tab1 = new WitiTask[list.Count];
            list.CopyTo(tab1);
            List<WitiTask> list1 = tab1.ToList();

            WitiTask[] tab2 = new WitiTask[list.Count];
            list.CopyTo(tab2);
            List<WitiTask> list2 = tab2.ToList();

            WitiTask[] tab3 = new WitiTask[list.Count];
            list.CopyTo(tab3);
            List<WitiTask> list3 = tab3.ToList();

            List<List<WitiTask>> g_list = new List<List<WitiTask>>();
            g_list.Add(list);
            g_list.Add(list1);
            g_list.Add(list2);
            g_list.Add(list3);

            //Wiele watków znajduje permutacje
            /*var watch = System.Diagnostics.Stopwatch.StartNew();
            Thread[] threads = new Thread[n];
            for (int i = 0; i < n; ++i)
            {
                int temp = i;
                threads[i] = new Thread(() => findObj.Permutations(g_list[temp], temp));
                threads[i].Name = String.Format("Thread: {0}", i);
            }
            foreach (Thread x in threads)
            {
                x.Start();
            }
            for (int i = 0; i < n; i++)
            {
                threads[i].Join();
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs + " ms");
            Console.WriteLine(findObj.Resualt.ToString());
            Console.ReadLine();*/

            //Jeden wątek znajduje permutacje
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            findObj.Permutations(list);
            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs1 + " ms");
            Console.WriteLine(findObj.Resualt.ToString());
            Console.ReadLine();
        }
    }
}
