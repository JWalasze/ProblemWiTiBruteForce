﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadsAlgorithm
{
    internal class FindPermutations
    {
        private WitiResualt resualt;
        private int number_of_tasks;

        public FindPermutations(int _tasks)
        {
            number_of_tasks = _tasks;
            resualt = new WitiResualt(number_of_tasks);
        }

        public WitiResualt Resualt { get { return resualt; } }

        public int NumberOfTasks { get { return number_of_tasks; } }

        public void Permutations(List<WitiTask> lista, int selected_digit)
        {
            Thread.Sleep(500);
            lista.Swap(0, selected_digit);
            int Ci = lista[0].P;
            int new_penalty = 0;
            if (Ci > lista[0].D)
            {
                new_penalty += lista[0].Weight * (Ci - lista[0].D);
            }
            Permutations(lista, 1, new_penalty, Ci);
            lista.Swap(0, selected_digit);
        }

        public void Permutations(List<WitiTask> lista)
        {
            Permutations(lista, 0, 0, 0);
        }

        private void Permutations(List<WitiTask> lista, int begin, int penalty, int C)
        {
            if (begin == lista.Count() - 1)
            {
                int last_item = lista.Count() - 1;
                int Ci = C + lista[last_item].P;
                int new_penalty = penalty;
                if (Ci > lista[last_item].D)
                {
                    new_penalty += lista[last_item].Weight * (Ci - lista[last_item].D);
                }
                
                lock(resualt)
                {
                    Console.Write("kara: " + new_penalty);
                    Console.WriteLine(lista.MyToString(this.NumberOfTasks) + Environment.NewLine);
                    if (resualt.Penaulty > new_penalty)
                    {
                        resualt.Penaulty = new_penalty;
                        resualt.Permutation.Clear();
                        foreach (var item in lista)
                        {
                            resualt.Permutation.Add(item);
                        }
                    }

                    else if (resualt.Penaulty == new_penalty)
                    {
                        foreach (var item in lista)
                        {
                            resualt.Permutation.Add(item);
                        }
                    }
                }
                return;
            }

            else
            {
                int temp_begin = begin + 1;
                for (int i = begin; i < lista.Count(); ++i)
                {
                    lista.Swap(begin, i);
                    int Ci = C + lista[begin].P;
                    int new_penalty = penalty;
                    if (Ci > lista[begin].D)
                    {
                        new_penalty += lista[begin].Weight * (Ci - lista[begin].D);
                    }
                    this.Permutations(lista, temp_begin, new_penalty, Ci);
                    lista.Swap(begin, i);
                }
            }
        }
    }

    internal static class MyExtansions
    {
        public static void Swap<T>(this List<T> lista, int i, int j)
        {
            (lista[j], lista[i]) = (lista[i], lista[j]);
        }

        public static string MyToString<T>(this List<T> lista, int number_of_tasks)
        {
            string str = string.Empty;
            int counter = 0;
            int perm_counter = 0;
            foreach (var item in lista)
            {
                if (counter % number_of_tasks == 0)
                {
                    ++perm_counter;
                    str += Environment.NewLine;
                    str += perm_counter.ToString() + " permutacja: ";
                }
                ++counter;
                str += item.ToString() + " "; 
            }
            return str;
        }
    }
}
