using System;
using System.Runtime.Serialization;

namespace OperationQuasarFireApp.CustomExceptions
{
    [Serializable]
    internal class SatellitesUpdateDataException : Exception
    {
        public SatellitesUpdateDataException()
        {
        }

        public SatellitesUpdateDataException(string message) : base(message)
        {
        }

        public SatellitesUpdateDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SatellitesUpdateDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}