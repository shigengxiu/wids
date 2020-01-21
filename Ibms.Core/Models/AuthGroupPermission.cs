using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibms.Core.Models
{
    public class AuthGroupPermission
    {
        public long Id { get; set; }

        public AuthGroup Group { get; set; }

        public AuthPermission Permission { get; set; }
    }
}
