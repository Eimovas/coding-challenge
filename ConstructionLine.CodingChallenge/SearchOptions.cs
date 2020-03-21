using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public sealed class SearchOptions
    {
        public HashSet<Size> Sizes { get;  }

        public HashSet<Color> Colors { get; }

        private SearchOptions(List<Size> sizes, List<Color> colors)
        {
            Sizes = sizes?.ToHashSet() ?? throw new ArgumentNullException(nameof(sizes));
            Colors = colors?.ToHashSet() ?? throw new ArgumentNullException(nameof(colors));
        }

        public static SearchOptions From(List<Size> sizes) => new SearchOptions(sizes, new List<Color>());
        public static SearchOptions From(List<Color> colors) => new SearchOptions(new List<Size>(), colors);
        public static SearchOptions From(List<Size> sizes, List<Color> colors) => new SearchOptions(sizes, colors);
        public static SearchOptions Empty() => new SearchOptions(new List<Size>(), new List<Color>());
    }
}