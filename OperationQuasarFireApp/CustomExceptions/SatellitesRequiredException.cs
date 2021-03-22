using System;
using System.Runtime.Serialization;

namespace OperationQuasarFireApp.CustomExceptions
{
    [Serializable]
    internal class SatellitesRequiredException : Exception
    {
        public SatellitesRequiredException()
        {
        }

        public SatellitesRequiredException(string message) : base(message)
        {
        }

        public SatellitesRequiredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SatellitesRequiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}