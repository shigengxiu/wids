using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibms.Core.Models
{
    public class AuthPermission
    {
        public long Id { get; set; }

        public PermissionType Type { get; set; }

        public string Name { get; set; }

        public string AuthorizeCode { get; set; }

        public int ResourceID { get; set; } // Model/Zone/Device/UI 
    }

    public enum PermissionType
    {
        API,
        Area,
        Device,
        Terminal,
        UI
    }
}
