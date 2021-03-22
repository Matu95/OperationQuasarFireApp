using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.CustomExceptions
{
    [Serializable]
    public class MessageLengthNotValidException : Exception
    {
        public MessageLengthNotValidException()
        {
        }

        public MessageLengthNotValidException(string message) : base(message)
        {
        }
    }
}
