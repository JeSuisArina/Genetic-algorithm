using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIT_2_Func
{
    class Population
    {
        Function F = new Function();
                
        public List<int> SelectedIndividuals(List<int> Generation, int count, double L)
        {
            var x = new List<int>();            
            var dict = new SortedDictionary<double, int>();

            dict = F.function(count, Generation);

            int l = dict.Count();
            l = l * Convert.ToInt32(L);

            for (int i = l; i < dict.Count; i++)
            {
                dict.Remove(i);
            }

            SortedDictionary<double, int>.ValueCollection valueColl = dict.Values;
            x = valueColl.ToList();

            return x;
        }        
    }
}
