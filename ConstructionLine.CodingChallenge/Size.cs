using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public sealed class Size
    {
        public Guid Id { get; }

        public string Name { get; }

        private Size(Guid id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            Id = id;
            Name = name;
        }
        
        public static Size Small = new Size(Guid.NewGuid(), "Small");
        public static Size Medium = new Size(Guid.NewGuid(), "Medium");
        public static Size Large = new Size(Guid.NewGuid(), "Large");


        public static List<Size> All = 
            new List<Size>
            {
                Small,
                Medium,
                Large
            };

        #region Equality

        private bool Equals(Size other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Size) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Size left, Size right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}