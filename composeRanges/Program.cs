using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composeRanges
{
    class Program
    {
        class Range
        {
            public int Start { get; set; }
            public int End { get; set; }
            public bool IsRange { get; set; }
            public override string ToString() { return IsRange ? string.Format("{0}->{1}", Start, End) : Start.ToString(); }
        }

        string[] composeRanges(int[] nums)
        {
            var ranges = new List<Range>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] - 1 != nums[i - 1]) ranges.Add(new Range() { Start = nums[i] });
                if (i > 0 && nums[i] - 1 == nums[i - 1])
                {
                    ranges[ranges.Count - 1].End = nums[i];
                    ranges[ranges.Count - 1].IsRange = true;
                }
            }
            return ranges.Select(range => range.ToString()).ToArray();
        }


        static void Main(string[] args)
        {
            var p = new Program();
            var r = p.composeRanges(new int[0]);
            foreach (string s in r)
                Console.WriteLine(s);
        }
    }
}
