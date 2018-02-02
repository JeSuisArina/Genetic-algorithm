using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIT_2_Func
{
    class Individuals
    {
        public List<int> Genes(int count)
        {
            var x = new List<int>();
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                x.Add(rand.Next(0, 127));
            }

            return x;
        }

        public List<string> BitGenes(int count, List<int> x)
        {            
            var Bits = new List<string>();

            foreach (var i in x)
            {
                bool[] b = new BitArray(new int[] { i }).Cast<bool>().Reverse().ToArray();
                Bits.Add(b.ToString());
            }

            //приведение всех строк списка к одной длине

            int max = 0;

            for (var b = 1; b < Bits.Count; b++)
            {
                max = Bits[b - 1].Length;
                if (max < Bits[b].Length) max = Bits[b].Length;
            }

            for (var b = 0; b < Bits.Count; b++)
            {
                if (Bits[b].Length < max)
                {
                    int m = max - Bits[b].Length;
                    for (int c = 0; c < m; c++)
                    {
                        Bits[b].Insert(0, "0");
                    }                    
                }
            }
            return Bits;
        }
    }
}
