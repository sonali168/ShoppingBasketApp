
using System;
using System.Collections.Generic;
using ShoppingBasketApp;
using Xunit;

namespace ShoppingBasketApp.Tests
{
    public class ShoppingBasketTests
    {
        private readonly ShoppingBasket _basket = new();

        [Fact]
        public void EmptyBasket_ReturnsZero()
        {
            Assert.Equal(0,
                _basket.CalculateTotal(new List<string>()));
        }

        [Theory]
        [InlineData("Apple", 35)]
        [InlineData("Banana", 20)]
        [InlineData("Melon", 50)]
        [InlineData("Lime", 15)]
        public void SingleItem_ReturnsCorrectPrice(
            string item, int expected)
        {
            Assert.Equal(expected,
                _basket.CalculateTotal(new List<string> { item }));
        }

        [Theory]
        [InlineData("apple", 35)]
        [InlineData("APPLE", 35)]
        [InlineData("aPpLe", 35)]
        [InlineData("banana", 20)]
        [InlineData("MELON", 50)]
        [InlineData("lime", 15)]
        public void ItemName_IsCaseInsensitive(
            string item, int expected)
        {
            Assert.Equal(expected,
                _basket.CalculateTotal(new List<string> { item }));
        }

        [Theory]
        [InlineData(" Apple ", 35)]
        [InlineData("  BANANA  ", 20)]
        [InlineData(" Lime ", 15)]
        public void ItemName_TrimsSurroundingSpaces(
            string item, int expected)
        {
            Assert.Equal(expected,
                _basket.CalculateTotal(new List<string> { item }));
        }

        [Fact]
        public void TwoApples_Returns70P()
        {
            Assert.Equal(70, _basket.CalculateTotal(
                new List<string> { "Apple", "Apple" }));
        }

        [Theory]
        [InlineData(1, 50)]
        [InlineData(2, 50)]
        [InlineData(3, 100)]
        [InlineData(4, 100)]
        [InlineData(5, 150)]
        public void MelonOffer_CalculatesCorrectPrice(
            int count, int expected)
        {
            var items = new List<string>();

            for (int i = 0; i < count; i++)
                items.Add("Melon");

            Assert.Equal(expected, _basket.CalculateTotal(items));
        }

        [Theory]
        [InlineData(1, 15)]
        [InlineData(2, 30)]
        [InlineData(3, 30)]
        [InlineData(4, 45)]
        [InlineData(5, 60)]
        [InlineData(6, 60)]
        public void LimeOffer_CalculatesCorrectPrice(
            int count, int expected)
        {
            var items = new List<string>();

            for (int i = 0; i < count; i++)
                items.Add("Lime");

            Assert.Equal(expected, _basket.CalculateTotal(items));
        }

        [Fact]
        public void MixedBasket_ReturnsCorrectTotal()
        {
            var items = new List<string>
            {
                "Apple", "Banana",
                "Melon", "Melon",
                "Lime", "Lime", "Lime"
            };

            Assert.Equal(135, _basket.CalculateTotal(items));
        }

        [Fact]
        public void MixedCaseBasket_ReturnsCorrectTotal()
        {
            var items = new List<string>
            {
                "apple", "BANANA",
                "Melon", "melon",
                " lime ", "LIME", "Lime"
            };

            Assert.Equal(135, _basket.CalculateTotal(items));
        }

        [Fact]
        public void UnknownItem_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                _basket.CalculateTotal(new List<string> { "Orange" }));
        }

        [Fact]
        public void NullBasket_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _basket.CalculateTotal(null!));
        }

        [Fact]
        public void NullItem_ThrowsException()
        {
            var items = new List<string> { null! };

            Assert.Throws<ArgumentException>(() =>
                _basket.CalculateTotal(items));
        }

        [Fact]
        public void EmptyItem_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                _basket.CalculateTotal(new List<string> { "" }));
        }

        [Fact]
        public void WhitespaceItem_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                _basket.CalculateTotal(new List<string> { "   " }));
        }
    }
}
