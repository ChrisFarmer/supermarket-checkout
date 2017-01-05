using System.Runtime.CompilerServices;
using GoCoSupermarket.DTO;

namespace GoCoSupermarket.BusinessLogic
{
    public static class PriceCalculatorFactory
    {
        private static IPriceCalculatorStrategy StandardPricingStrategy = null;
        private static IPriceCalculatorStrategy MultiBuyStrategy = null;

        public static IPriceCalculatorStrategy GetStrategy(StockKeepingUnit stockKeepingUnit)
        {
            if (stockKeepingUnit.Is(OfferType.MultiBuy))
            {
                return MultiBuyStrategyInstance;
            }

            if (stockKeepingUnit.Is(OfferType.Standard))
            {
                return StandardPricingStrategyInstance;
            }

            return new DateBasedStrategy();
        }

        private static IPriceCalculatorStrategy MultiBuyStrategyInstance
        {
            get
            {
                if (MultiBuyStrategy == null)
                {
                    MultiBuyStrategy = new MultiBuyStrategy();
                }

                return MultiBuyStrategy;
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
