namespace GoCoSupermarket.DTO
{
    /// <summary>
    /// Represents a special offer that a particular product may have.
    /// </summary>
    public struct Offer
    {
        /// <summary>
        /// The number of items required before the discount can be applied.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The total price that is paid for the items under the offer.
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
