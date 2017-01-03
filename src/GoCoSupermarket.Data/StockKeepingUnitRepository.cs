using GoCoSupermarket.DataInterfaces;
using GoCoSupermarket.DTO;
using GoCoSupermarket.Globalisation;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.Data
{
    public class StockKeepingUnitRepository : IStockKeepingUnitRepository
    {
        // This data would typically be pulled from a database
        private Dictionary<char, StockKeepingUnit> StockKeepingUnits = new Dictionary<char, StockKeepingUnit>
        {
            { 
                'A', 
                new StockKeepingUnit 
                {
                    ItemCode = 'A',
                    Price = 50.00M,
                    Offer = new Offer 
                    {
                        Number = 3,
                        TotalPrice = 130.00M
                    }
                } 
            },

            { 
                'B', 
                new StockKeepingUnit 
                {
                    ItemCode = 'B',
                    Price = 30.00M,
                    Offer = new Offer 
                    {
                        Number = 2,
                        TotalPrice = 45.00M
                    }
                } 
            },

            { 
                'C', 
                new StockKeepingUnit 
                {
                    ItemCode = 'C',
                    Price = 20.00M
                } 
            },

            { 
                'D', 
                new StockKeepingUnit 
                {
                    ItemCode = 'D',
                    Price = 15.00M
                } 
            }
        };

        public IEnumerable<StockKeepingUnit> GetStockKeepingUnits(IEnumerable<char> itemCodes)
        {
            return itemCodes.Select(itemCode =>
            {
                // Invalid product passed to the checkout, so inform the user 
                // instead of ignoring it to ensure that the price reported is not unexpected
                if (!StockKeepingUnits.ContainsKey(itemCode))
                {
                    throw new KeyNotFoundException(string.Format("{0}: '{1}'", ResourceStrings.ItemCodeNotRecognised, itemCode));
                }

                return StockKeepingUnits[itemCode];
            });
        }
    }
}
