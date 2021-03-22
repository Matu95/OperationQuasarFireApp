using OperationQuasarFireApp.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage(List<string[]> messages)
        {
            if (messages.Count < 3)
                throw new MessagesRequiredException("Son necesarios al menos tres mensajes");

            string[] result = messages.First();

            foreach (string[] message in messages)
            {
                if (result.Length != message.Length)
                    throw new MessageLengthNotValidException("Los mensajes deben tener el mismo tamaño");

                for (int i = 0; i < message.Length; i++)
                    if (!string.IsNullOrEmpty(message[i]))
                        result[i] = message[i];
            }


            return string.Join(" ", result);
        }
    }
}
