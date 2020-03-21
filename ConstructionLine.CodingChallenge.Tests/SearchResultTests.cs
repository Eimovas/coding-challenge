using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public sealed class SearchResultTests
    {
        [TestCaseSource(typeof(SearchResultTestCases), nameof(SearchResultTestCases.TestCases))]
        public void Given_FoundShirt_When_BuildingResult_Then_ReturnExpected(List<Shirt> shirts, List<SizeCount> expectedSizeCounts, 
            List<ColorCount> expectedColorCounts)
        {
            // arrange
            // act
            var result = SearchResults.From(shirts);

            // assert
            CollectionAssert.AreEquivalent(shirts, result.Shirts);
            CollectionAssert.AreEquivalent(expectedSizeCounts, result.SizeCounts);
            CollectionAssert.AreEquivalent(expectedColorCounts, result.ColorCounts);
        }

        public sealed class SearchResultTestCases
        {
            public static IEnumerable<TestCaseData> TestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new List<Shirt>(),
                        new List<SizeCount>()
                        {
                            new SizeCount(Size.Small, 0),
                            new SizeCount(Size.Medium, 0),
                            new SizeCount(Size.Large, 0)
                        },
                        new List<ColorCount>()
                        {
                            new ColorCount(Color.Black, 0),
                            new ColorCount(Color.Blue, 0),
                            new ColorCount(Color.Red, 0),
                            new ColorCount(Color.White, 0),
                            new ColorCount(Color.Yellow, 0)
                        }
                    );

                    yield return new TestCaseData(
                        new List<Shirt>() { TestShirts.SmallBlue, TestShirts.SmallBlue, TestShirts.SmallBlue },
                        new List<SizeCount>()
                        {
                            new SizeCount(Size.Small, 3),
                            new SizeCount(Size.Medium, 0),
                            new SizeCount(Size.Large, 0)
                        },
                        new List<ColorCount>()
                        {
                            new ColorCount(Color.Black, 0),
                            new ColorCount(Color.Blue, 3),
                            new ColorCount(Color.Red, 0),
                            new ColorCount(Color.White, 0),
                            new ColorCount(Color.Yellow, 0)
                        }
                    );

                    yield return new TestCaseData(
                        new List<Shirt>()
                        {
                            TestShirts.SmallBlue, TestShirts.MediumRed, TestShirts.LargeBlack, TestShirts.SmallBlack,
                            TestShirts.MediumYellow, TestShirts.LargeBlue
                        },
                        new List<SizeCount>()
                        {
                            new SizeCount(Size.Small, 2),
                            new SizeCount(Size.Medium, 2),
                            new SizeCount(Size.Large, 2)
                        },
                        new List<ColorCount>()
                        {
                            new ColorCount(Color.Black, 2),
                            new ColorCount(Color.Blue, 2),
                            new ColorCount(Color.Red, 1),
                            new ColorCount(Color.White, 0),
                            new ColorCount(Color.Yellow, 1)
                        }
                    );
                }
            }
        }
    }
}