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
            decimal totalCost = 0.0M;

            foreach (var itemCode in items.Keys) 
            {
                var strategy = PriceCalculatorFactory.GetStrategy(items[itemCode].First());
                totalCost += strategy.GetPrice(items[itemCode]);
            }

            return totalCost;
        }
    }
}