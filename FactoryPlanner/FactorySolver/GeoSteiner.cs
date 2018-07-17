using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPlanner.FactorySolver
{
    class GeoSteiner
    {
        [DllImport("GeoSteiner.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RectilinearSteiner(int nterms, double[] terms);

        public static void Test()
        {
            double[] terms = { 0, 0, 1, 9, 1, 14, 3, 4, 4, 10, 4, 13, 5, 3, 5, 15, 7, 0, 7, 8, 9, 3, 10, 5, 10, 11, 10, 14, 12, 1, 13, 3, 14, 10, 14, 12, 15, 5, 15, 7 };
            /* Compute Euclidean Steiner tree */
            int answer = RectilinearSteiner(20, terms);
            answer = answer;
        }
    }
}
