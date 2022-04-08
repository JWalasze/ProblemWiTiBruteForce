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

        public WitiResualt()
        {
            permutation = new List<WitiTask>();
            penaulty = 2147483647;
        }

        public override string ToString()
        {
            string str = String.Empty;
            str += "Optymalna wartość kary: " + penaulty + Environment.NewLine;
            str += "Znaleziona permutacja: " + permutation.MyToString() + Environment.NewLine;
            return str;
        }

    }
}
