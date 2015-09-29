using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SGEnviro.Utilities
{
    public class NumberParseException : Exception
    {
        public NumberParseException(string message) { }
    }

    public class Parsing
    {
        public static void ParseFloatOrThrowException(string value, out float destination, string message)
        {
            if (!float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out destination))
            {
                throw new NumberParseException(message);
            }
        }

        public static void ParseIntOrThrowException(string value, out int destination, string message)
        {
            if (!int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out destination))
            {
                throw new NumberParseException(message);
            }
        }
    }
}
