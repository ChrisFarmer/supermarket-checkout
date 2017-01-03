using GoCoSupermarket.BusinessLogicInterfaces;
using GoCoSupermarket.DTO.Exceptions;
using GoCoSupermarket.Globalisation;
using System.Linq;

namespace GoCoSupermarket.BusinessLogic
{
    public class StockValidatorBusinessLogic : IStockValidatorBusinessLogic
    {
        public void ValidateItemCodes(string itemCodes)
        {
            // Only accept letters to represent offer codes
            if (itemCodes.Any(itemCode => !char.IsLetter(itemCode)))
            {
                throw new ItemCodeException(ResourceStrings.OneOrMoreItemCodesAreInvalid);
            }
        }
    }
}
