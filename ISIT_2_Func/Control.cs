using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIT_2_Func
{
    class Control
    {
        Function F = new Function();

        public List<string> Recombination(int count, List<string> BitGenes, double L) //скрещивание
        {
            var NewGeneration = new List<string>();
            var rand = new Random();
            double r = rand.Next(0, 100) / 100;
            double Pc = rand.Next(60, 100) / 100;            
            int k = 0;

            while (k < count)
            {
                var parent1 = BitGenes[Convert.ToInt32(r) * count];
                var parent2 = BitGenes[Convert.ToInt32(r) * count];
                string child1 = "";
                string child2 = "";
                int point = rand.Next(0, parent1.Length);

                if (Pc > r)
                {
                    string cross = parent1;

                    for (int i = 0; i < point; i++)
                    {
                        cross = cross.Replace(cross[i], parent2[i]);
                        child1 = parent2.Replace(parent1[i], parent2[i]);
                        child2 = cross;
                    }
                    NewGeneration.Add(child1);
                    NewGeneration.Add(child2);
                }

                else
                {
                    child1 = parent1;
                    child2 = parent2;
                    NewGeneration.Add(child1);
                    NewGeneration.Add(child2);
                }

                k++;
            }

            return NewGeneration;
        }

        public List<string> Mutation(double L, List<string> Generation)
        {
            
            var Pm = Math.Pow(L, -1);
            var rand = new Random();
            var num = rand.Next(-50, 50) / 100;

            for (var k = 0; k < Generation.Count; k++)
            {
                for (var i = 0; i < Generation[k].Length; i++)
                {
                    if (Pm > num)
                    {
                        if (Generation[k][i] == 0)
                            Generation[k] = Generation[k].Replace(Generation[k][i], '1');
                        
                        else
                            Generation[k] = Generation[k].Replace(Generation[k][i], '0');
                    }
                }
            }

            return Generation;
        }
    }
}
