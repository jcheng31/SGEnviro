using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGEnviro.Utilities
{
    public static class DateParser
    {
        private const int YEAR_LENGTH = 4;
        private const int MONTH_LENGTH = 2;
        private const int DAY_LENGTH = 2;
        private const int HOUR_LENGTH = 2;
        private const int MINUTE_LENGTH = 2;
        private const int SECOND_LENGTH = 2;

        private const string PARSE_YEAR_ERROR = "Couldn't parse the year.";
        private const string PARSE_MONTH_ERROR = "Couldn't parse the month.";
        private const string PARSE_DAY_ERROR = "Couldn't parse the day.";
        private const string PARSE_HOUR_ERROR = "Couldn't parse the hour.";
        private const string PARSE_MINUTE_ERROR = "Couldn't parse the minutes.";
        private const string PARSE_SECOND_ERROR = "Couldn't parse the seconds.";

        public static DateTime Parse(string rawTimestamp)
        {
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

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
