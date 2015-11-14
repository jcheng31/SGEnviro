using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SGEnviro.Forecasts
{
    public class Pm25Update
    {
        public Pm25RegionalUpdate Central { get; set; }
        public Pm25RegionalUpdate East { get; set; }
        public Pm25RegionalUpdate North { get; set; }
        public Pm25RegionalUpdate South { get; set; }
        public Pm25RegionalUpdate West { get; set; }

        /// <summary>
        /// Constructs a Pm25Update from an XElement.
        /// Expects the XElement to be a "channel" node from NEA's
        /// PSI API.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static Pm25Update FromXElement(XElement channel)
        {
            var regionElements = channel.Descendants("region");
            var regionUpdates = regionElements.Select(x => Pm25RegionalUpdate.FromXElement(x));

            var update = new Pm25Update();
            foreach(var region in regionUpdates)
            {
                switch (region.Region)
                {
                    case Region.Central:
                        update.Central = region;
                        break;
                    case Region.East:
                        update.East = region;
                        break;
                    case Region.North:
                        update.North = region;
                        break;
                    case Region.South:
                        update.South = region;
                        break;
                    case Region.West:
                        update.West = region;
                        break;
                }
            }

            return update;
        }
    }
}
