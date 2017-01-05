using System.Collections.Generic;

namespace GoCoSupermarket.DTO
{
    /// <summary>
    /// Represents an item that can be purchased from the store which 
    /// may or may not have a special offer associated with it.
    /// </summary>
    public class StockKeepingUnit
    {
        /// <summary>
        /// The unique ID that will identify a product. e.g. 'A', 'B'
        /// </summary>
        public char ItemCode { get; set; }

        /// <summary>
        /// The standard price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// A special offer that may be available on the item.
        /// </summary>
        public MultiBuyOffer MultiBuyOffer { get; set; }

        public IEnumerable<ICalculateDiscountedPrice> OfferCalculator { get; set; }

        public bool Is(OfferType offerType)
        {
            return offerType == this.MultiBuyOffer.OfferType;
        }

        public decimal GetPrice(IEnumerable<StockKeepingUnit> skuGroup)
        {
            decimal totalPrice = 0.0M;

            foreach (var calculator in this.OfferCalculator)
            {
                totalPrice += calculator.CalculatePrice(skuGroup);
            }

            return totalPrice;
        }
    }
}
