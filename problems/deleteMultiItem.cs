using System;
using System.Collections.Generic;
using System.Linq;


namespace problems
{

    class DeleteMultipleItems
    {
        public int[] DeleteNth(int[] arr, int x)
        {
            // ...
            IList<int> indexArr = new List<int>();
            IDictionary<int, int> mapCount = new Dictionary<int, int>(arr.Length);

            // parse through array
            for (int i = 0; i < arr.Length; i++)
            {
                if (mapCount.ContainsKey(arr[i]))
                {
                    if (mapCount[arr[i]] < x)
                    {
                        mapCount[arr[i]] += 1;
                        indexArr.Add(arr[i]);
                    }
                }
                else
                {
                    mapCount.Add(arr[i], 1);
                    indexArr.Add(arr[i]);
                }
            }
            return indexArr.ToArray();
        }
    }
}
