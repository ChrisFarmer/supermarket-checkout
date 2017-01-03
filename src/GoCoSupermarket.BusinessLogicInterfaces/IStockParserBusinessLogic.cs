using GoCoSupermarket.DTO;
using System.Collections.Generic;

namespace GoCoSupermarket.BusinessLogicInterfaces
{
    /// <summary>
    /// Parses a set of stock.
    /// </summary>
    public interface IStockParserBusinessLogic
    {
        /// <summary>
        /// Parses item codes into a dictionary of the format: ['X', [SKU1, SKU2]], 
        /// where 'X' is the item code and [SKU1, SKU2] is an IEnumerable of StockKeepingUnits.
        /// </summary>
        /// <param name="items">A string representing the set of items purchased.</param>
        /// <returns>A Dictionary.</returns>
        Dictionary<char, IEnumerable<StockKeepingUnit>> ParseStockItems(string items);
    }
}