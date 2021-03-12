using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class MinimumRepetitionWindow
    {
        public int minimumRepetitionWindow(int[] array)
        {
            IDictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            (int maxDegree, int minWindow) = (int.MinValue, int.MaxValue);

            for (int i = 0; i < array.Length; i++)
            {
                if (map.ContainsKey(array[i]))
                {
                    if (map[array[i]].Count > 1)
                        map[array[i]][^1] = i;
                    else
                        map[array[i]].Add(i);
                }
                else
                {
                    var tmp = new List<int>();
                    tmp.Add(i);
                    map.Add(array[i], tmp);
                }

                // if (map[array[i]].Count > 1)
                // {
                //     maxDegree = Math.Max(maxDegree, map[array[i]].Count);
                //     minWindow = Math.Min(minWindow, (map[array[i]][^1] - map[array[i]][0] + 1));
                // }
            }

            foreach (int key in map.Keys)
            {
                if (map[key].Count > maxDegree)
                {
                    maxDegree = map[key].Count;
                    if ((map[key][^1] - map[key][0]) + 1 < minWindow)
                        minWindow = map[key][^1] - map[key][0] + 1;
                }
            }
            return minWindow;
        }
    }
}