using System;
using System.Collections.Generic;

namespace ChartStructLib.Common
{
    public class X
    {
        public string type { get; set; }
        public string categories { get; set; }
    }

    public class Y
    {
        public string label { get; set; }
    }

    public class Axis
    {
        public X x { get; set; }
        public Y y { get; set; }
    }

}
