using GoCoSupermarket.DTO;
using GoCoSupermarket.DTO.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.BusinessLogic
{

    public class DateBasedStrategy : IPriceCalculatorStrategy
    {
        public decimal GetPrice(IEnumerable<StockKeepingUnit> items)
        {
            return items.First().Price * (decimal) 0.9;
        }
    }
    public class MultiBuyStrategy : IPriceCalculatorStrategy
    {
        public decimal GetPrice(IEnumerable<StockKeepingUnit> items)
        {
            StockKeepingUnit sku = items.First();
            MultiBuyOffer multiBuyOffer = sku.MultiBuyOffer;

            int totalStandardPricedItems = items.Count() % multiBuyOffer.Number;

            return (totalStandardPricedItems * sku.Price) + ((items.Skip(totalStandardPricedItems).Count() / multiBuyOffer.Number) * multiBuyOffer.TotalPrice);
        }
    }
}
