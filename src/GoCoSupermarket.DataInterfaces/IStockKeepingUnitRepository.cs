using GoCoSupermarket.DTO;
using System.Collections.Generic;

namespace GoCoSupermarket.DataInterfaces
{
    /// <summary>
    /// DAL class which would, in a real life application, access
    /// the database to retrieve stock pricing.
    /// </summary>
    public interface IStockKeepingUnitRepository
    {
        /// <summary>
        /// Returns a set of StockKeepingUnits for each item purchased.
        /// </summary>
        /// <param name="itemCodes">The codes of the items purchased.</param>
        /// <returns></returns>
        IEnumerable<StockKeepingUnit> GetStockKeepingUnits(IEnumerable<char> itemCodes);
    }
}
