using System;

namespace GoCoSupermarket.DTO.Exceptions
{
    public class OfferNullException : Exception
    {
        public OfferNullException(MultiBuyOffer multiBuyOffer) : base()
        {
            this.MultiBuyOffer = multiBuyOffer;
        }
        
        public MultiBuyOffer MultiBuyOffer { get; private set; }
    }
}
