using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGEnviro.Forecasts;

namespace SGEnviroTest
{
    [TestClass]
    public class Pm25RegionalTest
    {
        [TestMethod]
        public void TestInitialization()
        {
            var elementText = @"<region>
                                    <id>rNO</id>
                                    <latitude>1.41803</latitude>
                                    <longitude>103.82000</longitude>
                                    <record timestamp=""20150929110000"">
                                        <reading type=""PM25_RGN_1HR"" value=""134""/>
                                    </record>
                                </region>";
            var element = XElement.Parse(elementText);

            var delta = 0.00001;
            var expectedLatitude = 1.41803;
            var expectedLongitude = 103.82;
            var expectedTimestamp = new DateTime(2015, 09, 29, 11, 00, 00);
            var expectedReading = 134;
            var expectedRegion = Region.North;

            var actual = Pm25RegionalUpdate.FromXElement(element);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedLatitude, actual.Latitude, delta);
            Assert.AreEqual(expectedLongitude, actual.Longitude, delta);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedReading, actual.Reading);
            Assert.AreEqual(expectedRegion, actual.Region);
        }
    }
}
