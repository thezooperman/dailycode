using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class Problem21
    {
        /*
           Given an array of time intervals (start, end) for classroom lectures
           (possibly overlapping), find the minimum number of rooms required.

           For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.
        */

        private IList<Interval> _intervals;
        internal class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

        public Problem21(int[] intervals)
        {
            _intervals = new List<Interval>(intervals.Length / 2);
            for (int i = 1, j = 0; i < intervals.Length; i += 2, j++)
            {
                Interval tmp = new Interval();
                tmp.Start = intervals[i - 1];
                tmp.End = intervals[i];
                _intervals.Add(tmp);
            }
        }

        public int problem21()
        {
            // sort the intervals
            _intervals = _intervals.OrderBy(x => x.Start).ThenBy(x => x.End).ToList<Interval>();

            (int rooms, int i, int j) = (0, 1, 0);
            int len = _intervals.Count;

            while (i < len && j < len)
            {
                if (_intervals[j].Start <= _intervals[i].End)
                {
                    rooms++;
                    i++;
                }
                else if (_intervals[i].End < _intervals[j].Start)
                {
                    rooms--;
                    j++;
                }
            }

            return rooms;
        }
    }
}