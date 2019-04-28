using System.Collections.Generic;

namespace NET.S._2019.Tkachenko._13
{
    public class Int32Comparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return 1;
            }
            else if (a.Length < b.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a.Pages > b.Pages)
            {
                return 1;
            }
            else if (a.Pages < b.Pages)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            if (a.GetDistanceFromZeroCenter() > b.GetDistanceFromZeroCenter())
            {
                return 1;
            }
            else if (a.GetDistanceFromZeroCenter() < b.GetDistanceFromZeroCenter())
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