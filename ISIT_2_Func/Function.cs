using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIT_2_Func
{
    class Function
    {
        public SortedDictionary<double, int> function(int count, List<int> Generation)
        {            
            var y = new List<double>();
            var dict = new SortedDictionary<double, int>();

            for (int i = 0; i < count; i++)
            {
                y.Add(Math.Pow(Generation[i], 2) + 4);
                //y.Add(Math.Pow(Generation[i], 2) - 4 * Generation[i]);
                //y.Add(Math.Pow(Generation[i], 2) - 100 * Generation[i]);
                try
                {
                    dict.Add(y[i], Generation[i]);
                }

                catch
                {
                    continue;
                }
            }

            return dict;
        }
    }
}
