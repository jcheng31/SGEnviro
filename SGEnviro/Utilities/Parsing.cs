using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGEnviro.Utilities
{
    public class Parsing
    {
        public static void ParseFloatOrThrowException(string value, out float destination, string message)
        {
            if (!float.TryParse(value, out destination))
            {
                throw new Exception(message);
            }
        }
    }
}
