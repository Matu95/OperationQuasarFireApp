﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Services
{
    public interface IMessageService
    {
        string GetMessage(List<string[]> messages);
    }
}
