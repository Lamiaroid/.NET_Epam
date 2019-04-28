using System;

namespace NET.S._2019.Tkachenko._13
{
    public class Point
    {
        public double X
        {
            get;
            private set;
        }

        public double Y
        {
            get;
            private set;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() || obj == null)
            {
                return false;
            }

            Point point = (Point)obj;

            return point.X == this.X &&
                   point.Y == this.Y;
        }

        public override int GetHashCode()
        {
            const int number = 15;
            int hashCode = 3;
            hashCode = (hashCode * this.X.GetHashCode()) + number;
            hashCode = (hashCode * this.Y.GetHashCode()) + number;
            return hashCode;
        }

        public override string ToString()
        {
            return $"X: {this.X}\nY: {this.Y}\n";
        }

        public double GetDistanceFromZeroCenter() => Math.Sqrt(X * X + Y * Y);
    }
}