using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using SGEnviro;
using SGEnviro.Forecasts;

namespace SGEnviroTest
{
    [TestClass]
    public class Pm25UpdateTest
    {
        [TestMethod]
        public void TestPm25UpdateDirectInit()
        {
            var elementText = @"<channel>
                                    <title>PM2.5 Update</title>
                                    <source>Airviro</source>
                                    <item>
                                        <region>
                                            <id>rNO</id>
                                            <latitude>1.41803</latitude>
                                            <longitude>103.82000</longitude>
                                            <record timestamp=""20150929110000"">
                                                <reading type=""PM25_RGN_1HR"" value=""134""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rCE</id>
                                            <latitude>1.35735</latitude>
                                            <longitude>103.82000</longitude>
                                            <record timestamp=""20150929110000"">
                                                <reading type=""PM25_RGN_1HR"" value=""199""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rEA</id>
                                            <latitude>1.35735</latitude>
                                            <longitude>103.94000</longitude>
                                            <record timestamp=""20150929110000"">
                                                <reading type=""PM25_RGN_1HR"" value=""237""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rWE</id>
                                            <latitude>1.35735</latitude>
                                            <longitude>103.70000</longitude>
                                            <record timestamp=""20150929110000"">
                                                <reading type=""PM25_RGN_1HR"" value=""163""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rSO</id>
                                            <latitude>1.29587</latitude>
                                            <longitude>103.82000</longitude>
                                            <record timestamp=""20150929110000"">
                                                <reading type=""PM25_RGN_1HR"" value=""201""/>
                                            </record>
                                        </region>
                                    </item>
                                </channel>";
            var element = XElement.Parse(elementText);

            var actual = Pm25Update.FromXElement(element);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.North);
            Assert.AreEqual(actual.North.Region, Region.North);
            Assert.AreEqual(actual.South.Region, Region.South);
            Assert.AreEqual(actual.East.Region, Region.East);
            Assert.AreEqual(actual.West.Region, Region.West);
            Assert.AreEqual(actual.Central.Region, Region.Central);
        }
    }
}
