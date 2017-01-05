using System;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.DTO
{
    public class StandardOffer : ICalculateDiscountedPrice
    {
        public decimal CalculatePrice(IEnumerable<StockKeepingUnit> skuGroup)
        {
            return -1;
        }
    }

    public class DateBasedOffer : ICalculateDiscountedPrice
    {
        private DateTime endDate;
        private decimal percentage;

        public DateBasedOffer(decimal percentage, DateTime endDate)
        {
            this.percentage = percentage;
            this.endDate = endDate;
        }

        public decimal CalculatePrice(IEnumerable<StockKeepingUnit> skuGroup)
        {
            return skuGroup.First().Price * this.percentage;
        }
    }
    /// <summary>
    /// Represents a special multiBuyOffer that a particular product may have.
    /// </summary>
    public class MultiBuyOffer : ICalculateDiscountedPrice
    {
        private OfferType _offerType; 
        public MultiBuyOffer() : this(OfferType.Standard) { }
        public MultiBuyOffer(OfferType offerType)
        {
            this._offerType = offerType;
        }

        public OfferType OfferType
        {
            get { return this._offerType; }
        }

        /// <summary>
        /// The number of items required before the discount can be applied.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The total price that is paid for the items under the multiBuyOffer.
        /// </summary>
        public decimal TotalPrice { get; set; }


        public decimal CalculatePrice(IEnumerable<StockKeepingUnit> skuGroup)
        {
            if (skuGroup.Count() > Number)
            {
                return TotalPrice;
            }

            return 0;
        }
    }

    public interface ICalculateDiscountedPrice
    {
        decimal CalculatePrice(IEnumerable<StockKeepingUnit> skuGroup);
    }

    public enum OfferType
    {
        Standard = 0,
        DateBased,
        MultiBuy
    }
}
