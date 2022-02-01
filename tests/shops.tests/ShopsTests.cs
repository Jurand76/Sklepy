using System;
using System.Net.NetworkInformation;
using System.Reflection;
using shops;
using Xunit;

namespace Shops.Tests
{
    public class ShopsTests
    {
        [Fact]
        public void CanSetNameFromReference()
        {
            var shop1 = GetShop("Leroy Merlin", "Katowice");
            this.SetName(shop1, "NewName", "NewCity");
            Assert.Equal("NewName", shop1.Name);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var shop2 = new SavedShop("Castorama", "Kraków");
            var shop1 = new SavedShop("OBI", "Kraków");
            var shop3 = new SavedShop("OBI", "Katowice");

            // po jednokrotnym wykonaniu testu należy wykomentować poniższe 3 linijki

            shop1.AddGrade(4);
            shop1.AddGrade(4);
            shop1.AddGrade(3);

            //act
            var result = shop1.GetStatistics();

            //assert
            Assert.Equal(3.667, Math.Round(result.Average, 3));
        }

        private SavedShop GetShop(string name, string city)
        {
            return new SavedShop(name, city);
        }

        private void SetName(SavedShop shop, string name, string city)
        {
            shop.Name = name;
        }
    }
}
