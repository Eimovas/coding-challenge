using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public sealed class SearchResults
    {
        public IReadOnlyList<Shirt> Shirts { get; }
        
        public IReadOnlyList<SizeCount> SizeCounts { get; }
        
        public IReadOnlyList<ColorCount> ColorCounts { get; }

        private SearchResults(IReadOnlyList<Shirt> shirtResult, IReadOnlyList<SizeCount> sizeCounts, IReadOnlyList<ColorCount> colorCounts)
        {
            Shirts = shirtResult ?? throw new ArgumentNullException(nameof(shirtResult));
            SizeCounts = sizeCounts ?? throw new ArgumentNullException(nameof(sizeCounts));
            ColorCounts = colorCounts ?? throw new ArgumentNullException(nameof(colorCounts));
        }

        public static SearchResults From(IReadOnlyList<Shirt> foundShirts)
        {
            if (foundShirts == null) throw new ArgumentNullException(nameof(foundShirts));

            var colorCountMap = Color.All.ToDictionary(c => c, _ => 0);
            var sizeCountMap = Size.All.ToDictionary(s => s, _ => 0);
            foreach (var shirt in foundShirts)
            {
                colorCountMap[shirt.Color] += 1;
                sizeCountMap[shirt.Size] += 1;
            }

            return new SearchResults(
                foundShirts,
                sizeCountMap.Select(kv => new SizeCount(kv.Key, kv.Value)).ToList(),
                colorCountMap.Select(kv => new ColorCount(kv.Key, kv.Value)).ToList());
        }
    }
    
    public sealed class SizeCount
    {
        public Size Size { get; }

        public int Count { get; }

        public SizeCount(Size size, int count)
        {
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Count = count;
        }

        #region Equality

        private bool Equals(SizeCount other)
        {
            return Equals(Size, other.Size) && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SizeCount) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Size != null ? Size.GetHashCode() : 0) * 397) ^ Count;
            }
        }

        public static bool operator ==(SizeCount left, SizeCount right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SizeCount left, SizeCount right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
    
    public sealed class ColorCount
    {
        public Color Color { get; }

        public int Count { get; }

        public ColorCount(Color color, int count)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color));
            Count = count;
        }

        #region Equality

        private bool Equals(ColorCount other)
        {
            return Equals(Color, other.Color) && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ColorCount) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Color != null ? Color.GetHashCode() : 0) * 397) ^ Count;
            }
        }

        public static bool operator ==(ColorCount left, ColorCount right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ColorCount left, ColorCount right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}