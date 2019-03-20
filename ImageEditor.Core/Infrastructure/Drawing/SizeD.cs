using System;

namespace ImageEditor.Infrastructure.Drawing
{
    public readonly struct SizeD : IEquatable<SizeD>
    {
        #region Fields
        
        public static readonly SizeD Empty = new SizeD(0, 0);

        #endregion

        #region Constructors

        public SizeD(double width, double height)
        {
            Width = width;
            Height = height;
        }

        #endregion

        #region Properties

        public double Width { get; }

        public double Height { get; }

        #endregion

        #region Methods

        public bool Equals(SizeD other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SizeD other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width.GetHashCode() * 397) ^ Height.GetHashCode();
            }
        }

        public static bool operator ==(SizeD left, SizeD right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SizeD left, SizeD right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"{Width}, {Height}";
        }

        #endregion
    }
}