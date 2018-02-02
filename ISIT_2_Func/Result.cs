using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIT_2_Func
{
    class Result
    {
        Individuals I = new Individuals();
        Control C = new Control();
        Population P = new Population();
        Function F = new Function();

        public int result(int count, int iter)
        {
            int res = 0;
            int i = 0;
            var Generation = new List<int>();
            var IntGeneration = new List<int>();
            var StringGeneration = new List<string>();
            var rand = new Random();
            double L = rand.Next(30, 70) / 100;
            IntGeneration = I.Genes(count);  

            while (i < iter)
            {                
                IntGeneration = P.SelectedIndividuals(IntGeneration, count, L);
                StringGeneration = I.BitGenes(count, IntGeneration);
                StringGeneration = C.Recombination(count, StringGeneration, L);
                StringGeneration = C.Mutation(L, StringGeneration);
                for (int j = 0; j < StringGeneration.Count; j++)
                    IntGeneration.Add(Convert.ToInt32(StringGeneration[j]));
                i++;
            }

            SortedDictionary<double, int>.ValueCollection valueColl = F.function(count, IntGeneration).Values;
            Generation = valueColl.ToList();
            res = Generation[0];
            return res;
        }
    }
}

