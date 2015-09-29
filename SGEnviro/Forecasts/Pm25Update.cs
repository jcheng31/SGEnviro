using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGEnviro.Forecasts
{
    public class Pm25Update
    {
        public Pm25RegionalUpdate Central { get; set; }
        public Pm25RegionalUpdate East { get; set; }
        public Pm25RegionalUpdate North { get; set; }
        public Pm25RegionalUpdate South { get; set; }
        public Pm25RegionalUpdate West { get; set; }
    }
}
