using System;

namespace GoCoSupermarket.DTO.Exceptions
{
    public class AppSettingsException : Exception
    {
        public AppSettingsException(string errorMsg) : base(errorMsg)
        {
        }
    }
}
