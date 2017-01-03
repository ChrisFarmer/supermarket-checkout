using GoCoSupermarket.DTO;
using System.Collections.Generic;

namespace GoCoSupermarket.BusinessLogicInterfaces
{
    /// <summary>
    /// Provides methods for calculating the cost of purchased items.
    /// </summary>
    public interface IPriceCalculatorBusinessLogic
    {
        /// <summary>
        /// Returns the total cost of an individual's shopping, applying any special
        /// offers available.
        /// </summary>
        /// <param name="items">A parsed Dictionary representing the items purchased.</param>
        /// <returns>A decimal representing the total cost of the items.</returns>
        decimal GetTotalCostOfItems(Dictionary<char, IEnumerable<StockKeepingUnit>> items);
    }
}
