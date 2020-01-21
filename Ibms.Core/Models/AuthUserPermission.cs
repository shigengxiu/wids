using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibms.Core.Models
{
    public class AuthUserPermission
    {
        public long Id { get; set; }

        public AuthUser User { get; set; }

        public AuthPermission Permission { get; set; }
    }
}
