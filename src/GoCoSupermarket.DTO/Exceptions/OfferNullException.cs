using System;

namespace GoCoSupermarket.DTO.Exceptions
{
    public class OfferNullException : Exception
    {
        public OfferNullException(Offer? offer) : base()
        {
            this.Offer = offer;
        }
        
        public Offer? Offer { get; private set; }
    }
}
