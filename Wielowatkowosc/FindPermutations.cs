using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsAlgorithm
{
    internal class FindPermutations
    {
        List<WitiTask> lista;

        public FindPermutations(List<WitiTask> _tasks)
        {
            lista = _tasks;
        }

        public void Permutations(int begin, int penalty, int C)
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
                Console.WriteLine(lista.MyToString() + "Kara: " + new_penalty);
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
                    this.Permutations(temp_begin, new_penalty, Ci);
                    lista.Swap(begin, i);
                }
            }
        }
    }

    internal static class MyExtansions
    {
        public static void Swap<T>(this List<T> lista, int i, int j)
        {
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
