using System;

namespace ConstructionLine.CodingChallenge
{
    public sealed class Shirt
    {
        public Guid Id { get; }

        public string Name { get; }

        public Size Size { get; }

        public Color Color { get; }

        public Shirt(Guid id, string name, Size size, Color color)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            Id = id;
            Name = name;
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        #region Equality

        private bool Equals(Shirt other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Shirt) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Shirt left, Shirt right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Shirt left, Shirt right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}