using System.Collections.Generic;

namespace NET.S._2019.Tkachenko._11
{
    public class TestComparerInt : IComparer<int>
    {
        public int Compare(int p1, int p2)
        {
            if (p1 > p2)
            {
                return 1;
            }
            else if (p1 < p2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class TestComparerDouble : IComparer<double>
    {
        public int Compare(double p1, double p2)
        {
            if (p1 > p2)
            {
                return 1;
            }
            else if (p1 < p2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class TestComparerString : IComparer<string>
    {
        public int Compare(string p1, string p2)
        {
            if (p1.Length > p2.Length)
            {
                return 1;
            }
            else if (p1.Length < p2.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}