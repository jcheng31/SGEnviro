using SGEnviro.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SGEnviro.Forecasts
{
    public class PsiRegionalUpdate
    {
        public Region Region { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// 24-hour PSI. Corresponds to NPSI.
        /// </summary>
        public int TwentyFourHourPsi { get; set; }

        /// <summary>
        /// 3-hour PSI. Corresponds to NPSI_PM_3HR.
        /// </summary>
        public int ThreeHourPsi { get; set; }

        /// <summary>
        /// 1-hour NO_2 concentration, measured in mu-g/m^3.
        /// Corresponds to NO2_1HR_MAX.
        /// </summary>
        public float OneHourNO2 { get; set; }

        /// <summary>
        /// 24-hour PM10 concentration, measured in mu-g/m^3.
        /// Corresponds to PM10_24HR.
        /// </summary>
        public float TwentyFourHourPM10 { get; set; }

        /// <summary>
        /// 24-hour PM25 concentration, measured in mu-g/m^3.
        /// Corresponds to PM25_24HR.
        /// </summary>
        public float TwentyFourHourPM25 { get; set; }

        /// <summary>
        /// 24-hour SO2 concentration, measured in mu-g/m^3.
        /// Corresponds to SO2_24HR.
        /// </summary>
        public float TwentyFourHourSO2 { get; set; }

        /// <summary>
        /// 8-hour CO concentration, measured in mu-g/m^3.
        /// Corresponds to CO_8HR_MAX.
        /// </summary>
        public float EightHourCO { get; set; }

        /// <summary>
        /// 8-hour O3 concentration, measured in mu-g/m^3.
        /// Corresponds to O3_8HR_MAX.
        /// </summary>
        public float EightHourO3 { get; set; }

        /// <summary>
        /// CO sub-index, used in calculation of overall PSI.
        /// Corresponds to NPSI_CO.
        /// </summary>
        public int COSubIndex { get; set; }

        /// <summary>
        /// NO2 sub-index, used in calculation of overall PSI.
        /// </summary>
        public int NO2SubIndex { get; set; }

        /// <summary>
        /// O3 sub-index, used in calculation of overall PSI.
        /// </summary>
        public int O3SubIndex { get; set; }

        /// <summary>
        /// PM10 sub-index, used in calculation of overall PSI.
        /// </summary>
        public int PM10SubIndex { get; set; }

        /// <summary>
        /// PM25 sub-index, used in calculation of overall PSI.
        /// </summary>
        public int PM25SubIndex { get; set; }

        /// <summary>
        /// SO2 sub-index, used in calculation of overall PSI.
        /// </summary>
        public int SO2SubIndex { get; set; }

        private const string TWENTY_FOUR_HOUR_PSI_TYPE = "NPSI";
        private const string THREE_HOUR_PSI_TYPE = "NPSI_PM25_3HR";
        private const string ONE_HOUR_NO2_TYPE = "NO2_1HR_MAX";
        private const string TWENTY_FOUR_HOUR_PM10_TYPE = "PM10_24HR";
        private const string TWENTY_FOUR_HOUR_PM25_TYPE = "PM25_24HR";
        private const string TWENTY_FOUR_HOUR_SO2_TYPE = "SO2_24HR";
        private const string EIGHT_HOUR_CO_TYPE = "CO_8HR_MAX";
        private const string EIGHT_HOUR_O3_TYPE = "O3_8HR_MAX";
        private const string CO_SUBINDEX_TYPE = "NPSI_CO";
        private const string NO2_SUBINDEX_TYPE = "NPSI_NO2";
        private const string O3_SUBINDEX_TYPE = "NPSI_O3";
        private const string PM10_SUBINDEX_TYPE = "NPSI_PM10";
        private const string PM25_SUBINDEX_TYPE = "NPSI_PM25";
        private const string SO2_SUBINDEX_TYPE = "NPSI_SO2";

        private const string PARSE_LATITUDE_ERROR = "Couldn't parse latitude.";
        private const string PARSE_LONGITUDE_ERROR = "Couldn't parse longitude.";
        private const string PARSE_TWENTY_FOUR_HOUR_PSI_ERROR = "Couldn't parse 24-hour PSI.";
        private const string PARSE_THREE_HOUR_PSI_ERROR = "Couldn't parse 3-hour PSI.";
        private const string PARSE_ONE_HOUR_NO2_ERROR = "Couldn't parse 1-hour NO2.";
        private const string PARSE_TWENTY_FOUR_HOUR_PM10_ERROR = "Couldn't parse 24-hour PM10.";
        private const string PARSE_TWENTY_FOUR_HOUR_PM25_ERROR = "Couldn't parse 24-hour PM25.";
        private const string PARSE_TWENTY_FOUR_HOUR_SO2_ERROR = "Couldn't parse 24-hour SO2.";
        private const string PARSE_EIGHT_HOUR_CO_ERROR = "Couldn't parse 8-hour CO.";
        private const string PARSE_EIGHT_HOUR_O3_ERROR = "Couldn't parse 8-hour O3.";
        private const string PARSE_CO_SUBINDEX_ERROR = "Couldn't parse CO sub-index.";
        private const string PARSE_NO2_SUBINDEX_ERROR = "Couldn't parse NO2 sub-index.";
        private const string PARSE_O3_SUBINDEX_ERROR = "Couldn't parse O3 sub-index.";
        private const string PARSE_PM10_SUBINDEX_ERROR = "Couldn't parse PM10 sub-index.";
        private const string PARSE_PM25_SUBINDEX_ERROR = "Couldn't parse PM25 sub-index.";
        private const string PARSE_SO2_SUBINDEX_ERROR = "Couldn't parse SO2 sub-index.";

        public static PsiRegionalUpdate FromXElement(XElement regionElement)
        {
            Region region = RegionUtils.Parse(regionElement.Element("id").Value);

            var timeStamp = DateParser.Parse(regionElement.Element("record").Attribute("timestamp").Value);

            var readingElements = regionElement.Descendants("reading");

            float latitude;
            NumberParser.ParseFloatOrThrowException(regionElement.Element("latitude").Value, out latitude, PARSE_LATITUDE_ERROR);

            float longitude;
            NumberParser.ParseFloatOrThrowException(regionElement.Element("longitude").Value, out longitude, PARSE_LONGITUDE_ERROR);

            float oneHourNO2 = 0;
            float twentyFourHourPM10 = 0;
            float twentyFourHourPM25 = 0;
            float twentyFourHourSO2 = 0;
            float eightHourCO = 0;
            float eightHourO3 = 0;
            int twentyFourHourPsi = 0;
            int threeHourPsi = 0;
            int coSubIndex = 0;
            int no2SubIndex = 0;
            int o3SubIndex = 0;
            int pm10SubIndex = 0;
            int pm25SubIndex = 0;
            int so2SubIndex = 0;

            foreach(var element in readingElements)
            {
                var value = element.Attribute("value").Value;
                switch(element.Attribute("type").Value)
                {
                    case TWENTY_FOUR_HOUR_PSI_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out twentyFourHourPsi, PARSE_TWENTY_FOUR_HOUR_PSI_ERROR);
                        break;
                    case THREE_HOUR_PSI_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out threeHourPsi, PARSE_THREE_HOUR_PSI_ERROR);
                        break;
                    case ONE_HOUR_NO2_TYPE:
                        NumberParser.ParseFloatOrThrowException(value, out oneHourNO2, PARSE_ONE_HOUR_NO2_ERROR);
                        break;
                    case TWENTY_FOUR_HOUR_PM10_TYPE:
                        NumberParser.ParseFloatOrThrowException(value, out twentyFourHourPM10, PARSE_TWENTY_FOUR_HOUR_PM10_ERROR);
                        break;
                    case TWENTY_FOUR_HOUR_PM25_TYPE:
                        NumberParser.ParseFloatOrThrowException(value, out twentyFourHourPM25, PARSE_TWENTY_FOUR_HOUR_PM25_ERROR);
                        break;
                    case TWENTY_FOUR_HOUR_SO2_TYPE:
                        NumberParser.ParseFloatOrThrowException(value, out twentyFourHourSO2, PARSE_TWENTY_FOUR_HOUR_SO2_ERROR);
                        break;
                    case EIGHT_HOUR_CO_TYPE:
                        NumberParser.ParseFloatOrThrowException(value, out eightHourCO, PARSE_EIGHT_HOUR_CO_ERROR);
                        break;
                    case EIGHT_HOUR_O3_TYPE:
                        NumberParser.ParseFloatOrThrowException(value, out eightHourO3, PARSE_EIGHT_HOUR_O3_ERROR);
                        break;
                    case CO_SUBINDEX_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out coSubIndex, PARSE_CO_SUBINDEX_ERROR);
                        break;
                    case NO2_SUBINDEX_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out no2SubIndex, PARSE_CO_SUBINDEX_ERROR);
                        break;
                    case O3_SUBINDEX_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out o3SubIndex, PARSE_O3_SUBINDEX_ERROR);
                        break;
                    case PM10_SUBINDEX_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out pm10SubIndex, PARSE_PM10_SUBINDEX_ERROR);
                        break;
                    case PM25_SUBINDEX_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out pm25SubIndex, PARSE_PM25_SUBINDEX_ERROR);
                        break;
                    case SO2_SUBINDEX_TYPE:
                        NumberParser.ParseIntOrThrowException(value, out so2SubIndex, PARSE_SO2_SUBINDEX_ERROR);
                        break;
                }
            }

            return new PsiRegionalUpdate
            {
                Latitude = latitude,
                Longitude = longitude,
                Region = region,
                TimeStamp = timeStamp,
                TwentyFourHourPsi = twentyFourHourPsi,
                ThreeHourPsi = threeHourPsi,
                OneHourNO2 = oneHourNO2,
                TwentyFourHourPM10 = twentyFourHourPM10,
                TwentyFourHourPM25 = twentyFourHourPM25,
                TwentyFourHourSO2 = twentyFourHourSO2,
                EightHourCO = eightHourCO,
                EightHourO3 = eightHourO3,
                COSubIndex = coSubIndex,
                NO2SubIndex = no2SubIndex,
                O3SubIndex = o3SubIndex,
                PM10SubIndex = pm10SubIndex,
                PM25SubIndex = pm25SubIndex,
                SO2SubIndex = so2SubIndex
            };
        }
    }
}
