﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibms.Core.Models
{
    public class BaseDevice
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DeviceType Type { get; set; }
    }
}
