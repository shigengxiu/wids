using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ibms.Core.Models
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        public DbSet<Ibms.Core.Models.BaseDevice> BaseDevices { get; set; }

        public DbSet<Ibms.Core.Models.DeviceType> DeviceType { get; set; }

        public DbSet<Ibms.Core.Models.ApiModel> ApiModel { get; set; }

        public DbSet<Ibms.Core.Models.Area> Area { get; set; }

        public DbSet<Ibms.Core.Models.AuthUser> AuthUser { get; set; }

        public DbSet<Ibms.Core.Models.AuthGroup> AuthGroup { get; set; }

        public DbSet<Ibms.Core.Models.AuthPermission> AuthPermission { get; set; }

        public DbSet<Ibms.Core.Models.AuthUserGroup> AuthUserGroup { get; set; }

        public DbSet<Ibms.Core.Models.AuthUserPermission> AuthUserPermission { get; set; }

        public DbSet<Ibms.Core.Models.AuthGroupPermission> AuthGroupPermission { get; set; }
    }
}
