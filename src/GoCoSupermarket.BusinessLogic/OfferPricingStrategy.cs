using GoCoSupermarket.DTO;
using GoCoSupermarket.DTO.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.BusinessLogic
{
    public class OfferPricingStrategy : IPriceCalculatorStrategy
    {
        public decimal GetPrice(IEnumerable<StockKeepingUnit> items)
        {
            StockKeepingUnit sku = items.First();
            Offer? offer = sku.Offer;

            // Appreciate this is not the case for our "database", but this sort of validation
            // would be necessary in a real life application
            if (!offer.HasValue) 
            {
                throw new OfferNullException(sku.Offer);
            }

            int totalStandardPricedItems = items.Count() % offer.Value.Number;

            return (totalStandardPricedItems * sku.Price) + ((items.Skip(totalStandardPricedItems).Count() / offer.Value.Number) * offer.Value.TotalPrice);
        }
    }
}
