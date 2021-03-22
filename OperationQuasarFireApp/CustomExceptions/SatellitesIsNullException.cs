using System;
using System.Runtime.Serialization;

namespace OperationQuasarFireApp.CustomExceptions
{
    [Serializable]
    internal class SatellitesIsNullException : Exception
    {
        public SatellitesIsNullException()
        {
        }

        public SatellitesIsNullException(string message) : base(message)
        {
        }

        public SatellitesIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SatellitesIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}