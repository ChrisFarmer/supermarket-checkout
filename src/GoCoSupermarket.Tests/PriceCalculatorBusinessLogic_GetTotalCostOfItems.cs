using GoCoSupermarket.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarketCheckout.Tests
{
    public class PriceCalculatorBusinessLogic_GetTotalCostOfItems : TestBase
    {
        [TestCase("")]
        [TestCase("A")]
        [TestCase("AB")]
        [TestCase("CDBA")]
        [TestCase("AA")]
        [TestCase("AAA")]
        [TestCase("AAABB")]
        public void Should_return_the_correct_price(string items)
        {
            // Arrange
            var itemsToPurchase = new Dictionary<char, IEnumerable<StockKeepingUnit>>();
            var itemsGrouped = items.ToCharArray().GroupBy(c => c);
            int groupCount = 0;

            foreach (var group in itemsGrouped) 
            {
                var skuList = new List<StockKeepingUnit>();
                StockKeepingUnit sku = this.Items.First(kvp => kvp.Key == group.Key).Value;

                groupCount = group.Count();
                for (int i = 0; i < groupCount; i++)
                {
                    skuList.Add(sku);
                }

                itemsToPurchase[group.Key] = skuList.AsEnumerable();
            }

            // Act
            decimal totalPrice = this.PriceCalculatorBusinessLogic.GetTotalCostOfItems(itemsToPurchase);

            // Assert
            Assert.That(totalPrice, Is.EqualTo(ExpectedOutcomes[items]));
        }
    }
}
