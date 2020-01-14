using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Ibms.Core.Interfaces
{
    interface ICoreService
    {
        public void LogInfo(string message);
    }
}
