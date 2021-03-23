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
            messages = messages.Where(x => x != null).ToList();

            if (messages.Count() == 0)
                return null;

            string[] result = getStuctureMessage(messages);

            return decryptMessage(messages, result);
        }

        private string[] getStuctureMessage(List<string[]> messages)
        {
            messages = messages.OrderByDescending(x => x.Length).ToList();

            return messages.First();
        }

        private string decryptMessage(List<string[]> messages, string[] result)
        {
            try
            {
                foreach (string[] message in messages)
                {
                    if (message != null && message.Count() > 0)
                        for (int i = 0; i < message.Length; i++)
                            if (!string.IsNullOrEmpty(message[i]) && !result.Contains(message[i]))
                                result[i] = message[i];
                }
            }
            catch(Exception)
            {
                throw new ErrorException("Ocurrió un error al desifrar mensaje");
            }

            return string.Join(" ", result);
        }
    }
}
