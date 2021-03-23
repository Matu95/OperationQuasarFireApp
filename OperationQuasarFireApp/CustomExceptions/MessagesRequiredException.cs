using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.CustomExceptions
{
    [Serializable]
    public class ErrorException : Exception
    {
        public ErrorException()
        {
        }

        public ErrorException(string message) : base(message)
        {
        }
    }
}
