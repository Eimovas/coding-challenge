using System;

namespace ConstructionLine.CodingChallenge.Tests
{
    public sealed class TestShirts
    {
        public static Shirt SmallRed = new Shirt(Guid.NewGuid(), "small-red", Size.Small, Color.Red);
        public static Shirt MediumRed = new Shirt(Guid.NewGuid(), "medium-red", Size.Medium, Color.Red);
        public static Shirt LargeRed = new Shirt(Guid.NewGuid(), "large-red", Size.Large, Color.Red);
        public static Shirt SmallBlue = new Shirt(Guid.NewGuid(), "small-blue", Size.Small, Color.Blue);
        public static Shirt MediumBlue = new Shirt(Guid.NewGuid(), "medium-blue", Size.Medium, Color.Blue);
        public static Shirt LargeBlue = new Shirt(Guid.NewGuid(), "large-blue", Size.Large, Color.Blue);
        public static Shirt SmallWhite = new Shirt(Guid.NewGuid(), "small-white", Size.Small, Color.White);
        public static Shirt MediumWhite = new Shirt(Guid.NewGuid(), "medium-white", Size.Medium, Color.White);
        public static Shirt LargeWhite = new Shirt(Guid.NewGuid(), "large-white", Size.Large, Color.White);
        public static Shirt SmallBlack = new Shirt(Guid.NewGuid(), "small-black", Size.Small, Color.Black);
        public static Shirt MediumBlack = new Shirt(Guid.NewGuid(), "medium-black", Size.Medium, Color.Black);
        public static Shirt LargeBlack = new Shirt(Guid.NewGuid(), "large-black", Size.Large, Color.Black);
        public static Shirt SmallYellow = new Shirt(Guid.NewGuid(), "small-yellow", Size.Small, Color.Yellow);
        public static Shirt MediumYellow = new Shirt(Guid.NewGuid(), "medium-yellow", Size.Medium, Color.Yellow);
        public static Shirt LargeYellow = new Shirt(Guid.NewGuid(), "large-yellow", Size.Large, Color.Yellow);
    }
}