using System.Collections.Generic;

namespace GoCoSupermarket.BusinessLogicInterfaces
{
    /// <summary>
    /// Provides methods for validating a set of items purchased.
    /// </summary>
    public interface IStockValidatorBusinessLogic
    {
        /// <summary>
        /// Validates a set of items and throws exceptions if errors are encountered.
        /// </summary>
        /// <param name="itemCodes">The items purchased.</param>
        void ValidateItemCodes(string itemCodes);
    }
}
