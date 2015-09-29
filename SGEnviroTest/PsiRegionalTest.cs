using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGEnviro.Forecasts;
using System.Xml.Linq;
using SGEnviro;

namespace SGEnviroTest
{
    [TestClass]
    public class PsiRegionalTest
    {
        [TestMethod]
        public void TestPsiRegionalInitialization()
        {
            var elementText = @"<region>
                                    <id>rNO</id>
                                    <latitude>1.41803</latitude>
                                    <longitude>103.82000</longitude>
                                    <record timestamp=""20150929200000"">
                                        <reading type=""NPSI"" value=""164""/>
                                        <reading type=""NPSI_PM25_3HR"" value=""169""/>
                                        <reading type=""NO2_1HR_MAX"" value=""43""/>
                                        <reading type=""PM10_24HR"" value=""161""/>
                                        <reading type=""PM25_24HR"" value=""116""/>
                                        <reading type=""SO2_24HR"" value=""6""/>
                                        <reading type=""CO_8HR_MAX"" value=""2.01""/>
                                        <reading type=""O3_8HR_MAX"" value=""86""/>
                                        <reading type=""NPSI_CO"" value=""20""/>
                                        <reading type=""NPSI_O3"" value=""36""/>
                                        <reading type=""NPSI_PM10"" value=""106""/>
                                        <reading type=""NPSI_PM25"" value=""164""/>
                                        <reading type=""NPSI_SO2"" value=""4""/>
                                    </record>
                                 </region>";

            var element = XElement.Parse(elementText);
            var actual = PsiRegionalUpdate.FromXElement(element);

            var delta = 0.01;

            var expectedRegion = Region.North;
            Assert.AreEqual(expectedRegion, actual.Region);

            var expectedPsi = 164;
            Assert.AreEqual(expectedPsi, actual.TwentyFourHourPsi);

            var expectedThreeHourPsi = 169;
            Assert.AreEqual(expectedThreeHourPsi, actual.ThreeHourPsi);

            var expectedNO2 = 43;
            Assert.AreEqual(expectedNO2, actual.OneHourNO2);

            var expectedTwentyFourHourPM10 = 161;
            Assert.AreEqual(expectedTwentyFourHourPM10, actual.TwentyFourHourPM10);

            var expectedTwentyFourHourPM25 = 116;
            Assert.AreEqual(expectedTwentyFourHourPM25, actual.TwentyFourHourPM25);

            var expectedTwentyFourHourSO2 = 6;
            Assert.AreEqual(expectedTwentyFourHourSO2, actual.TwentyFourHourSO2);

            var expectedEightHourCO = 2.01;
            Assert.AreEqual(expectedEightHourCO, actual.EightHourCO, delta);

            var expectedEightHourO3 = 86;
            Assert.AreEqual(expectedEightHourO3, actual.EightHourO3);

            var expectedCOSubIndex = 20;
            Assert.AreEqual(expectedCOSubIndex, actual.COSubIndex);

            var expectedO3SubIndex = 36;
            Assert.AreEqual(expectedO3SubIndex, actual.O3SubIndex);

            var expectedPM10SubIndex = 106;
            Assert.AreEqual(expectedPM10SubIndex, actual.PM10SubIndex);

            var expectedPM25SubIndex = 164;
            Assert.AreEqual(expectedPM25SubIndex, actual.PM25SubIndex);

            var expectedSO2SubIndex = 4;
            Assert.AreEqual(expectedSO2SubIndex, actual.SO2SubIndex);
        }
    }
}
