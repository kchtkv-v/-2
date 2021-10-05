using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_11
{
    public class Class1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mas">массив</param>
        /// <param name="raznitsa">разница чисел</param>
        public static void Raschet(int[] mas, out int raznitsa)
        {
            raznitsa = mas[0];
            for (int i = 1; i < mas.Length; i++)
            {
               raznitsa-=mas[i];
            }
        } 
    }
}
