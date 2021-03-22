using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.CustomExceptions
{
    [Serializable]
    public class MessagesRequiredException : Exception
    {
        public MessagesRequiredException()
        {
        }

        public MessagesRequiredException(string message) : base(message)
        {
        }
    }
}
