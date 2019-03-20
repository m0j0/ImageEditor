using System;

namespace ImageEditor.Infrastructure.Drawing
{
    public readonly struct PointD : IEquatable<PointD>
    {
        #region Constructors

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Properties

        public double X { get; }

        public double Y { get; }

        #endregion

        #region Methods

        public bool Equals(PointD other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is PointD other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static bool operator ==(PointD left, PointD right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointD left, PointD right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        #endregion
    }
}