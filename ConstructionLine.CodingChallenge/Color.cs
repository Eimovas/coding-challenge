using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public sealed class Color
    {
        public Guid Id { get; }

        public string Name { get; }

        private Color(Guid id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            Id = id;
            Name = name;
        }

        public static Color Red = new Color(Guid.NewGuid(), "Red");
        public static Color Blue = new Color(Guid.NewGuid(), "Blue");
        public static Color Yellow = new Color(Guid.NewGuid(), "Yellow");
        public static Color White = new Color(Guid.NewGuid(), "White");
        public static Color Black = new Color(Guid.NewGuid(), "Black");
        
        public static List<Color> All =
            new List<Color>
            {
                Red,
                Blue,
                Yellow,
                White,
                Black
            };

        #region Equality

        private bool Equals(Color other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Color) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Color left, Color right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Color left, Color right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}