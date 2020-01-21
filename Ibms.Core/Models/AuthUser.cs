using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibms.Core.Models
{
    public class AuthUser
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsSuperuser { get; set; }

        public DateTime DateJoined { get; set; }

        public DateTime LastLogin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActived { get; set; }
    }
}
