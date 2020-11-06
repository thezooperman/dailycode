using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;


namespace problems
{
    public class Kata
    {
        public int[] SortArray(int[] array)
        {
            if (array == null || array.Length == 0)
                return array;

            var oddNumbers = array.Where(x => x % 2 == 1).OrderBy(x => x).ToList();
            var oddIndex = 0;
            return array.Select(x => (x % 2 == 1) ? oddNumbers[oddIndex++] : x).ToArray();
        }
    }
}
