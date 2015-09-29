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
        private const string PARSE_YEAR_ERROR = "Couldn't parse the year.";
        private const string PARSE_MONTH_ERROR = "Couldn't parse the month.";
        private const string PARSE_DAY_ERROR = "Couldn't parse the day.";
        private const string PARSE_HOUR_ERROR = "Couldn't parse the hour.";
        private const string PARSE_MINUTE_ERROR = "Couldn't parse the minutes.";
        private const string PARSE_SECOND_ERROR = "Couldn't parse the seconds.";

        private const string XML_PM25_READING_TYPE = "PM25_RGN_1HR";

        private const int YEAR_LENGTH = 4;
        private const int MONTH_LENGTH = 2;
        private const int DAY_LENGTH = 2;
        private const int HOUR_LENGTH = 2;
        private const int MINUTE_LENGTH = 2;
        private const int SECOND_LENGTH = 2;

        public Region Region { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public DateTime TimeStamp { get; set; }
        public float Reading { get; set; }

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

            var rawTimestamp = region.Element("record").Attribute("timestamp").Value;
            int year;
            NumberParser.ParseIntOrThrowException(rawTimestamp.Substring(0, YEAR_LENGTH), out year, PARSE_YEAR_ERROR);

            int month;
            const int monthStartPosition = YEAR_LENGTH;
            NumberParser.ParseIntOrThrowException(rawTimestamp.Substring(monthStartPosition, MONTH_LENGTH), out month, PARSE_MONTH_ERROR);

            int day;
            const int dayStartPosition = YEAR_LENGTH + MONTH_LENGTH;
            NumberParser.ParseIntOrThrowException(rawTimestamp.Substring(dayStartPosition, DAY_LENGTH), out day, PARSE_DAY_ERROR);

            int hour;
            const int hourStartPosition = YEAR_LENGTH + MONTH_LENGTH + DAY_LENGTH;
            NumberParser.ParseIntOrThrowException(rawTimestamp.Substring(hourStartPosition, HOUR_LENGTH), out hour, PARSE_HOUR_ERROR);

            int minute;
            const int minuteStartPosition = YEAR_LENGTH + MONTH_LENGTH + DAY_LENGTH + HOUR_LENGTH;
            NumberParser.ParseIntOrThrowException(rawTimestamp.Substring(minuteStartPosition, MINUTE_LENGTH), out minute, PARSE_MINUTE_ERROR);

            int second;
            const int secondStartPosition = YEAR_LENGTH + MONTH_LENGTH + DAY_LENGTH + HOUR_LENGTH + MINUTE_LENGTH;
            NumberParser.ParseIntOrThrowException(rawTimestamp.Substring(secondStartPosition, SECOND_LENGTH), out second, PARSE_SECOND_ERROR);
            

            return new Pm25RegionalUpdate
            {
                Region = ourRegion,
                Reading = readingValue,
                Latitude = latitude,
                Longitude = longitude,
                Timestamp = new DateTime(year, month, day, hour, minute, second)
            };
        }
    }
}