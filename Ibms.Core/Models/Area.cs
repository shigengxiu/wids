using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibms.Core.Models
{
    public class Area
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Floor { get; set; }

        public AreaType Type { get; set; }

        public bool IsControlArea { get; set; }

        public bool IsKeyArea { get; set; }

        public Area ParentArea { get; set; }


    }

    public enum AreaType    // 待定义
    {
        Other
    }
}
