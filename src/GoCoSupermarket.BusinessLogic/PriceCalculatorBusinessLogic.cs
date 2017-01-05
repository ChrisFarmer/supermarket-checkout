using GoCoSupermarket.BusinessLogicInterfaces;
using GoCoSupermarket.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.BusinessLogic
{
    public class PriceCalculatorBusinessLogic : IPriceCalculatorBusinessLogic
    {
        public decimal GetTotalCostOfItems(Dictionary<char, IEnumerable<StockKeepingUnit>> items)
        {
            var skuGroup = items.First().Value;
            var runningTotal = 0M;
            foreach (var stockKeepingUnit in skuGroup)
            {
                runningTotal = stockKeepingUnit.GetPrice(skuGroup);
            }
            return runningTotal;
        }
    }
}