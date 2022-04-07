using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsAlgorithm
{
    internal class FindPermutations
    {
        readonly int amountOfTasks;
        public static int ind = 0;

        public FindPermutations(int value)
        {
            amountOfTasks = value;
        }

        public void Permutations(List<int> lista, int begin, int penaulty)
        {
            if (begin == lista.Count()-1)
            {
                Console.WriteLine(lista.MyToString());
                //Liczenie kary
                //Sprawdzenie z tablicą z maina, czy jest to lepsza 'kara' -> tutaj mutex
                return;
            }

            else
            {
                int temp_begin = begin + 1;
                for (int i = begin; i < lista.Count(); ++i)
                {
                    lista.Swap(begin, i);
                    //Liczenie kary posrednie
                    this.Permutations(lista, temp_begin, penaulty);
                    lista.Swap(begin, i);
                }
            }
        }
    }

    internal static class MyExtansions
    {
        public static void Swap<T>(this List<T> lista, int i, int j)
        {
            //Console.WriteLine("Indeksy: " + i + ", " + j);
            T temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }
        
        public static string MyToString<T>(this List<T> lista)
        {
            string str = string.Empty;
            foreach (var item in lista)
            {
                str += item.ToString() + ", ";
            }
            return str;
        }
    }
}
