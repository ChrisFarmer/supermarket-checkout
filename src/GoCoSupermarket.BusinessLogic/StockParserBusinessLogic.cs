using GoCoSupermarket.BusinessLogicInterfaces;
using GoCoSupermarket.DataInterfaces;
using GoCoSupermarket.DTO;
using GoCoSupermarket.DTO.Exceptions;
using GoCoSupermarket.Globalisation;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.BusinessLogic
{
    public class StockParserBusinessLogic : IStockParserBusinessLogic
    {
        private readonly IStockKeepingUnitRepository stockKeepingUnitRepo;
        private readonly IStockValidatorBusinessLogic stockValidatorBusinessLogic;

        public StockParserBusinessLogic(IStockValidatorBusinessLogic stockValidatorBusinessLogic, IStockKeepingUnitRepository stockKeepingUnitRepo)
        {
            this.stockValidatorBusinessLogic = stockValidatorBusinessLogic;
            this.stockKeepingUnitRepo = stockKeepingUnitRepo;
        }

        public Dictionary<char, IEnumerable<StockKeepingUnit>> ParseStockItems(string rawStockData)
        {
            string formattedStockData = rawStockData.ToUpper();

            this.stockValidatorBusinessLogic.ValidateItemCodes(formattedStockData);

            IEnumerable<char> itemCodes = formattedStockData.ToCharArray();
            IEnumerable<StockKeepingUnit> stockKeepingUnits = this.stockKeepingUnitRepo.GetStockKeepingUnits(itemCodes);

            return this.CategoriseStockKeepingUnits(stockKeepingUnits, itemCodes);
        }

        /// <summary>
        /// Takes a set of SKUs and organises them into a dictionary, where the key is the item code, and the value is the set of items with that offer code.
        /// </summary>
        /// <param name="stockKeepingUnits">The set of SKUs purchased.</param>
        /// <param name="itemCodes">A set of item codes representing the items purchased.</param>
        /// <returns>A dictionary.</returns>
        private Dictionary<char, IEnumerable<StockKeepingUnit>> CategoriseStockKeepingUnits(IEnumerable<StockKeepingUnit> stockKeepingUnits, IEnumerable<char> itemCodes)
        {
            Dictionary<char, IEnumerable<StockKeepingUnit>> stock = new Dictionary<char, IEnumerable<StockKeepingUnit>>();
            
            var itemCodesGrouped = itemCodes.GroupBy(itemCode => itemCode);
            foreach (var itemCodeGroup in itemCodesGrouped)
            {
                stock.Add(itemCodeGroup.Key, stockKeepingUnits.Where(sku => sku.ItemCode == itemCodeGroup.Key));
            }

            return stock;
        }
    }
}
