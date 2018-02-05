using System;

namespace TipsCalculator.CrossCutting.Exceptions
{
    [Serializable]
    public class RateConvertException : Exception
    {
        public RateConvertException()
        {
        }

        public RateConvertException(string message)
            : base(message)
        {
        }

        public RateConvertException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
