using System;

namespace ImageEditor.Infrastructure.Drawing
{
    public readonly struct Size : IEquatable<Size>
    {
        #region Fields
        
        public static readonly Size Empty = new Size(0, 0);

        #endregion

        #region Constructors

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        #endregion

        #region Properties

        public int Width { get; }

        public int Height { get; }

        #endregion

        #region Methods

        public bool Equals(Size other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Size other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width.GetHashCode() * 397) ^ Height.GetHashCode();
            }
        }

        public static bool operator ==(Size left, Size right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Size left, Size right)
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
