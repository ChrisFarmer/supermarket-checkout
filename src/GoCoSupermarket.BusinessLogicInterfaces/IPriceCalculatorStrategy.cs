using GoCoSupermarket.DTO;
using System.Collections.Generic;

namespace GoCoSupermarket.BusinessLogic
{
    /// <summary>
    /// An interface to using which the price of different types of items can be calculated.
    /// </summary>
    public interface IPriceCalculatorStrategy
    {
        /// <summary>
        /// Returns the total price for a set of items.
        /// </summary>
        /// <param name="items">An IEnumerable of StockKeepingUnit objects.</param>
        /// <returns>A decimal representing the total price of the items.</returns>
        decimal GetPrice(IEnumerable<StockKeepingUnit> items);
    }
}
