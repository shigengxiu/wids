using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ibms.Core.Interfaces;

namespace Ibms.Core.Services
{
    public class CoreService : ICoreService
    {
        public ILogger Logger { get; set; }

        void ICoreService.LogInfo(string message)
        {
            Logger.LogInformation(message);
        }
    }
}
