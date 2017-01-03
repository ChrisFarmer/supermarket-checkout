using System;

namespace GoCoSupermarket.DTO.Exceptions
{
    public class ItemCodeException : Exception
    {
        public ItemCodeException(string errorMsg) : base(errorMsg)
        {
        }
    }
}
