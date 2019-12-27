using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Ibms.Core.Hubs
{
    /// <summary>
    /// 需扩展为强制中心类型，使用 Hub<T>强键入 Hub: https://docs.microsoft.com/zh-cn/aspnet/core/signalr/hubs?view=aspnetcore-3.1
    /// </summary>
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message + " recieved!");
        }
    }
}
