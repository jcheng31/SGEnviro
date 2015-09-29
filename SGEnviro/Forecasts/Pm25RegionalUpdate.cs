using System;

namespace SGEnviro.Forecasts
{
    public enum Region
    {
        Central,
        East,
        North,
        South,
        West
    }

    public class Pm25RegionalUpdate
    {
        public Region Region { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public DateTime Timestamp { get; set; }
        public float Reading { get; set; }
    }
}