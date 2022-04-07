using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsAlgorithm
{
    internal class WitiTask
    {
        private static int ind = 0;
        private int index;
        private int p;
        private int weight;
        private int d;

        public int Index { get { return ind; } }

        public int P { get { return p; } }

        public int Weight { get { return weight; } }

        public int D { get { return d; } }

        public WitiTask(int p_value, int weight_value, int d_value)
        {
            index = ++ind;
            this.p = p_value;
            this.weight = weight_value;
            this.d = d_value;
        }

        public override string ToString()
        {
            string str = string.Empty;

            str += "Index: " + index + " ";

            return str;
        }
    }
}
