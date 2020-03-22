using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public sealed class SearchEngineTests : SearchEngineTestsBase
    {
        [Test]
        public void Test()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = SearchOptions.From(
                new List<Size> { Size.Small },
                new List<Color> { Color.Red }
            );

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [TestCaseSource(typeof(SearchEngineTestCases), nameof(SearchEngineTestCases.TestCases))]
        public void Given_Shirts_When_VariousSearchOptions_Then_ReturnValid(List<Shirt> shirts, SearchOptions searchOptions,
            SearchResults expected)
        {
            // arrange
            var sut = new SearchEngine(shirts);

            // act
            var result = sut.Search(searchOptions);

            // assert
            CollectionAssert.AreEquivalent(expected.Shirts, result.Shirts);
        }
        
        public sealed class SearchEngineTestCases
        {
            public static IEnumerable<TestCaseData> TestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new List<Shirt>(),
                        SearchOptions.Empty(),
                        SearchResults.From(new List<Shirt>())
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() {TestShirts.SmallBlue, TestShirts.MediumRed, TestShirts.LargeBlack, TestShirts.LargeYellow },
                        SearchOptions.Empty(),
                        SearchResults.From(new List<Shirt>() { TestShirts.SmallBlue, TestShirts.MediumRed, TestShirts.LargeBlack, TestShirts.LargeYellow })
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() {TestShirts.SmallBlue, TestShirts.MediumRed, TestShirts.LargeBlack, TestShirts.LargeYellow },
                        SearchOptions.From(
                            new List<Size>() {Size.Large, Size.Medium, Size.Small},
                            new List<Color>() {Color.Black, Color.Blue}
                        ),
                        SearchResults.From(new List<Shirt>() { TestShirts.SmallBlue, TestShirts.LargeBlack })
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() {TestShirts.SmallBlue, TestShirts.MediumRed, TestShirts.LargeBlack, TestShirts.LargeYellow },
                        SearchOptions.From(
                            new List<Color>() {Color.Black, Color.Blue}
                        ),
                        SearchResults.From(new List<Shirt>() { TestShirts.SmallBlue, TestShirts.LargeBlack })
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() {TestShirts.SmallBlue, TestShirts.MediumRed, TestShirts.LargeBlack, TestShirts.LargeYellow },
                        SearchOptions.From(
                            new List<Size>() {Size.Large, Size.Medium, Size.Small}
                        ),
                        SearchResults.From(new List<Shirt>() { TestShirts.SmallBlue, TestShirts.MediumRed, TestShirts.LargeBlack, TestShirts.LargeYellow })
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() { TestShirts.SmallBlue, TestShirts.SmallBlue, TestShirts.SmallBlue, TestShirts.SmallBlue },
                        SearchOptions.From(
                            new List<Size>() { Size.Large, Size.Medium, Size.Small },
                            new List<Color>() { Color.Black, Color.Blue }
                        ),
                        SearchResults.From(new List<Shirt>() { TestShirts.SmallBlue, TestShirts.SmallBlue, TestShirts.SmallBlue, TestShirts.SmallBlue })
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() { TestShirts.SmallBlue, TestShirts.SmallRed, TestShirts.SmallBlack, TestShirts.SmallYellow, TestShirts.SmallWhite },
                        SearchOptions.From(
                            new List<Size>() { Size.Large, Size.Medium, Size.Small },
                            new List<Color>() { Color.Black, Color.Blue, Color.White }
                        ),
                        SearchResults.From(new List<Shirt>() { TestShirts.SmallBlue, TestShirts.SmallBlack, TestShirts.SmallWhite })
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() { TestShirts.SmallBlue, TestShirts.MediumBlue, TestShirts.LargeBlack },
                        SearchOptions.From(
                            new List<Color>() { Color.Red }
                        ),
                        SearchResults.From(new List<Shirt>())
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() { TestShirts.SmallBlue, TestShirts.MediumRed },
                        SearchOptions.From(
                            new List<Size>() { Size.Large }
                        ),
                        SearchResults.From(new List<Shirt>())
                    );
                }
            }
        }
    }
}
