using GoCoSupermarket.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.BusinessLogic
{
    public class StandardPricingStrategy : IPriceCalculatorStrategy
    {
        public decimal GetPrice(IEnumerable<StockKeepingUnit> items)
        {
            return items.Sum(sku => sku.Price);
        }
    }
}
