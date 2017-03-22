using System;
using System.Runtime.Serialization;

namespace TryCatchException
{
    [Serializable]
    class StockVideException : Exception
    {
        public StockVideException()
        {
        }

        public StockVideException(string message) : base(message)
        {
        }

        public StockVideException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StockVideException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}