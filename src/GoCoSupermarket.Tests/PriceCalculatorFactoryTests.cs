using GoCoSupermarket.BusinessLogic;
using GoCoSupermarket.DTO;
using NUnit.Framework;

namespace GoCoSupermarketCheckout.Tests
{
    public class PriceCalculatorFactoryTests
    {
        [Test]
        public void should_return_multi_buy_strategy_when_given_type_is_multi_buy()
        {
            var sku = new StockKeepingUnit {MultiBuyOffer = new MultiBuyOffer(OfferType.MultiBuy)};
            var strategy = PriceCalculatorFactory.GetStrategy(sku);
            Assert.That(strategy, Is.TypeOf(typeof(MultiBuyStrategy)));
        }

        [Test]
        public void should_return_standard_strategy_when_given_type_is_standard()
        {
            var sku = new StockKeepingUnit { MultiBuyOffer = new MultiBuyOffer(OfferType.Standard) };
            var strategy = PriceCalculatorFactory.GetStrategy(sku);
            Assert.That(strategy, Is.TypeOf(typeof(StandardPricingStrategy)));
        }

        [Test]
        public void should_return_date_based_strategy_when_given_type_is_date_based()
        {
            var sku = new StockKeepingUnit { MultiBuyOffer = new MultiBuyOffer(OfferType.DateBased) };
            var strategy = PriceCalculatorFactory.GetStrategy(sku);
            Assert.That(strategy, Is.TypeOf(typeof(DateBasedStrategy)));
        }
    }


}