using GoCoSupermarket.DTO;

namespace GoCoSupermarket.BusinessLogic
{
    internal static class PriceCalculatorFactory
    {
        private static IPriceCalculatorStrategy StandardPricingStrategy = null;
        private static IPriceCalculatorStrategy OfferPricingStrategy = null;

        internal static IPriceCalculatorStrategy GetStrategy(StockKeepingUnit stockKeepingUnit)
        {
            return stockKeepingUnit.Offer.HasValue ? OfferPricingStrategyInstance : StandardPricingStrategyInstance; 
        }

        private static IPriceCalculatorStrategy OfferPricingStrategyInstance
        {
            get
            {
                if (OfferPricingStrategy == null)
                {
                    OfferPricingStrategy = new OfferPricingStrategy();
                }

                return OfferPricingStrategy;
            }
        }

        private static IPriceCalculatorStrategy StandardPricingStrategyInstance
        {
            get
            {
                if (StandardPricingStrategy == null) 
                {
                    StandardPricingStrategy = new StandardPricingStrategy();
                }

                return StandardPricingStrategy;
            }
        }
    }
}
