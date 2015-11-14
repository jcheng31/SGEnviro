using System;
using System.Linq;
using System.Xml.Linq;
using SGEnviro.Utilities;

namespace SGEnviro.Forecasts
{
    public class Pm25RegionalUpdate
    {
        private const string PARSE_PM25_ERROR = "Couldn't parse PM2.5 value.";
        private const string PARSE_LATITUDE_ERROR = "Couldn't parse latitude.";
        private const string PARSE_LONGITUDE_ERROR = "Couldn't parse longitude.";

        private const string XML_PM25_READING_TYPE = "PM25_RGN_1HR";

        public Region Region { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public DateTime TimeStamp { get; set; }
        public float Reading { get; set; }

        /// <summary>
        /// Constructs a Pm25RegionalUpdate from an XElement.
        /// Expects the XElement to be a "region" node in the XML response from
        /// NEA's PSI API.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static Pm25RegionalUpdate FromXElement(XElement region)
        {
            Region ourRegion = RegionUtils.Parse(region.Element("id").Value);

            var readingElement = (from element in region.Descendants("reading")
                                  where (string)element.Attribute("type") == XML_PM25_READING_TYPE
                                  select element).First();
            float readingValue;
            NumberParser.ParseFloatOrThrowException(readingElement.Attribute("value").Value, out readingValue, PARSE_PM25_ERROR);

            float latitude;
            NumberParser.ParseFloatOrThrowException(region.Element("latitude").Value, out latitude, PARSE_LATITUDE_ERROR);

            float longitude;
            NumberParser.ParseFloatOrThrowException(region.Element("longitude").Value, out longitude, PARSE_LONGITUDE_ERROR);

            var rawTimeStamp = region.Element("record").Attribute("timestamp").Value;
            var timestamp = DateParser.Parse(rawTimeStamp);

            return new Pm25RegionalUpdate
            {
                Region = ourRegion,
                Reading = readingValue,
                Latitude = latitude,
                Longitude = longitude,
                TimeStamp = timestamp
            };
        }
    }
}