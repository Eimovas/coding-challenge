using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public sealed class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts ?? throw new ArgumentNullException(nameof(shirts));
        }

        public SearchResults Search(SearchOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            var foundShirts = (options.Colors.Any(), options.Sizes.Any()) switch
            {
                (true, true) => _shirts.Where(s => options.Colors.Contains(s.Color) && options.Sizes.Contains(s.Size)).ToList(),
                (false, true) => _shirts.Where(s => options.Sizes.Contains(s.Size)).ToList(),
                (true, false) => _shirts.Where(s => options.Colors.Contains(s.Color)).ToList(),
                _ => _shirts
            };

            return SearchResults.From(foundShirts);
        }
    }
}