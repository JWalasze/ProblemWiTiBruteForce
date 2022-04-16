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
            var rand = new Random();
            int n = 3;
            int number_of_tasks = 9;
            int temp_number = (int)(number_of_tasks/n);
            //Console.WriteLine(temp_number);
            List<WitiTask> list = new List<WitiTask>();
            for (int i = 0; i < number_of_tasks; i++)
            {
                list.Add(new WitiTask(rand.Next(1,19), rand.Next(1,19), rand.Next(1,19)));
            }
            
            FindPermutations findObj = new FindPermutations(list.Count);

            WitiTask[] tab1 = new WitiTask[list.Count];
            list.CopyTo(tab1);
            List<WitiTask> list1 = tab1.ToList();
            FindPermutations findObj1 = new FindPermutations(list1.Count);
            List<WitiResualt> listResualt = new List<WitiResualt>();
            for (int j = 0; j < n; ++j)
            {
                listResualt.Add(new WitiResualt(number_of_tasks));
            }

            //Wiele watków znajduje permutacje
            
            Thread[] threads = new Thread[n];
            int temp = 0;
            for (int i = 0; i < n; ++i)
            {
                int _i = i;
                int temp_i = temp;
                threads[i] = new Thread(() => findObj.Permutations(list, temp_i, temp_number, listResualt[_i]));
                temp += temp_number;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
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
            Console.WriteLine("Czas trwania szukania optymalnej permutacji: " + elapsedMs + " ms");
            WitiResualt final = new WitiResualt(number_of_tasks);
            for (int j = 0; j < listResualt.Count; ++j)
            {
                if (final.Penaulty > listResualt[j].Penaulty)
                {
                    final.Penaulty = listResualt[j].Penaulty;
                    final.Permutation.Clear();
                    foreach (var item in listResualt[j].Permutation)
                    {
                        final.Permutation.Add(item);
                    }
                }

                else if (final.Penaulty == listResualt[j].Penaulty)
                {
                    foreach (var item in listResualt[j].Permutation)
                    {
                        final.Permutation.Add(item);
                    }
                }
            }
            Console.WriteLine(final.ToString());

            //Jeden wątek znajduje permutacje
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            WitiResualt resualt = findObj1.Permutations(list1);

            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedMilliseconds;
            Console.WriteLine("Czas trwania szukania optymalnej permutacji: " + elapsedMs1 + " ms");
            Console.WriteLine(resualt.ToString());
            Console.ReadLine();
        }
    }
}
