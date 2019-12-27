using System;
using System.Threading.Tasks;
using System.Net.Http;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace Ibms.Client.Test
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            await TestIndentity.Test1();
      
        }
    }
}
