using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsAlgorithm
{
    internal class WitiResualt
    {
        private List<WitiTask> permutation;
        private int penaulty;
        private int number_of_tasks;

        public List<WitiTask> Permutation 
        { 
            get { return permutation; } 
            set { permutation = value; }
        }

        public int Penaulty 
        { 
            get { return penaulty; } 
            set { penaulty = value; }
        }

        public WitiResualt(int _tasks_number)
        {
            permutation = new List<WitiTask>();
            penaulty = 2147483647;
            number_of_tasks = _tasks_number;
        }

        public override string ToString()
        {
            string str = String.Empty;
            str += "Optymalna wartość kary: " + penaulty + Environment.NewLine;
            str += "Znalezione permutacje: ";
            str += permutation.MyToString(number_of_tasks);
            return str;
        }

    }
}
