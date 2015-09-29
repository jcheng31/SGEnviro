using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using SGEnviro.Forecasts;
using SGEnviro;

namespace SGEnviroTest
{
    [TestClass]
    public class PsiUpdateTest
    {
        [TestMethod]
        public void TestPsiUpdateDirectInit()
        {
            var elementText = @"<channel>
                                    <title>PSI Update</title>
                                    <source>Airviro</source>
                                    <item>
                                        <region>
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
                                         </region>
                                         <region>
                                            <id>NRS</id>
                                            <latitude>0</latitude>
                                            <longitude>0</longitude>
                                            <record timestamp=""20150929200000"">
                                                <reading type=""NPSI"" value=""204""/>
                                                <reading type=""NPSI_PM25_3HR"" value=""167""/>
                                                <reading type=""NO2_1HR_MAX"" value=""43""/>
                                                <reading type=""PM10_24HR"" value=""178""/>
                                                <reading type=""PM25_24HR"" value=""154""/>
                                                <reading type=""SO2_24HR"" value=""29""/>
                                                <reading type=""CO_8HR_MAX"" value=""2.26""/>
                                                <reading type=""O3_8HR_MAX"" value=""92""/>
                                                <reading type=""NPSI_CO"" value=""23""/>
                                                <reading type=""NPSI_O3"" value=""39""/>
                                                <reading type=""NPSI_PM10"" value=""114""/>
                                                <reading type=""NPSI_PM25"" value=""204""/>
                                                <reading type=""NPSI_SO2"" value=""18""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rCE</id>
                                            <latitude>1.35735</latitude>
                                            <longitude>103.82000</longitude>
                                            <record timestamp=""20150929200000"">
                                                <reading type=""NPSI"" value=""163""/>
                                                <reading type=""NPSI_PM25_3HR"" value=""124""/>
                                                <reading type=""NO2_1HR_MAX"" value=""39""/>
                                                <reading type=""PM10_24HR"" value=""153""/>
                                                <reading type=""PM25_24HR"" value=""115""/>
                                                <reading type=""SO2_24HR"" value=""23""/>
                                                <reading type=""CO_8HR_MAX"" value=""1.87""/>
                                                <reading type=""O3_8HR_MAX"" value=""92""/>
                                                <reading type=""NPSI_CO"" value=""19""/>
                                                <reading type=""NPSI_O3"" value=""39""/>
                                                <reading type=""NPSI_PM10"" value=""102""/>
                                                <reading type=""NPSI_PM25"" value=""163""/>
                                                <reading type=""NPSI_SO2"" value=""14""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rEA</id>
                                            <latitude>1.35735</latitude>
                                            <longitude>103.94000</longitude>
                                            <record timestamp=""20150929200000"">
                                                <reading type=""NPSI"" value=""204""/>
                                                <reading type=""NPSI_PM25_3HR"" value=""178""/>
                                                <reading type=""NO2_1HR_MAX"" value=""19""/>
                                                <reading type=""PM10_24HR"" value=""168""/>
                                                <reading type=""PM25_24HR"" value=""154""/>
                                                <reading type=""SO2_24HR"" value=""15""/>
                                                <reading type=""CO_8HR_MAX"" value=""2.26""/>
                                                <reading type=""O3_8HR_MAX"" value=""79""/>
                                                <reading type=""NPSI_CO"" value=""23""/>
                                                <reading type=""NPSI_O3"" value=""33""/>
                                                <reading type=""NPSI_PM10"" value=""110""/>
                                                <reading type=""NPSI_PM25"" value=""204""/>
                                                <reading type=""NPSI_SO2"" value=""9""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rWE</id>
                                            <latitude>1.35735</latitude>
                                            <longitude>103.70000</longitude>
                                            <record timestamp=""20150929200000"">
                                                <reading type=""NPSI"" value=""203""/>
                                                <reading type=""NPSI_PM25_3HR"" value=""193""/>
                                                <reading type=""NO2_1HR_MAX"" value=""30""/>
                                                <reading type=""PM10_24HR"" value=""178""/>
                                                <reading type=""PM25_24HR"" value=""152""/>
                                                <reading type=""SO2_24HR"" value=""27""/>
                                                <reading type=""CO_8HR_MAX"" value=""1.78""/>
                                                <reading type=""O3_8HR_MAX"" value=""74""/>
                                                <reading type=""NPSI_CO"" value=""18""/>
                                                <reading type=""NPSI_O3"" value=""31""/>
                                                <reading type=""NPSI_PM10"" value=""114""/>
                                                <reading type=""NPSI_PM25"" value=""203""/>
                                                <reading type=""NPSI_SO2"" value=""17""/>
                                            </record>
                                        </region>
                                        <region>
                                            <id>rSO</id>
                                            <latitude>1.29587</latitude>
                                            <longitude>103.82000</longitude>
                                            <record timestamp=""20150929200000"">
                                                <reading type=""NPSI"" value=""201""/>
                                                <reading type=""NPSI_PM25_3HR"" value=""171""/>
                                                <reading type=""NO2_1HR_MAX"" value=""30""/>
                                                <reading type=""PM10_24HR"" value=""171""/>
                                                <reading type=""PM25_24HR"" value=""151""/>
                                                <reading type=""SO2_24HR"" value=""29""/>
                                                <reading type=""CO_8HR_MAX"" value=""1.76""/>
                                                <reading type=""O3_8HR_MAX"" value=""77""/>
                                                <reading type=""NPSI_CO"" value=""18""/>
                                                <reading type=""NPSI_O3"" value=""33""/>
                                                <reading type=""NPSI_PM10"" value=""111""/>
                                                <reading type=""NPSI_PM25"" value=""201""/>
                                                <reading type=""NPSI_SO2"" value=""18""/>
                                            </record>
                                        </region>
                                    </item>
                                </channel>";
            var element = XElement.Parse(elementText);

            var actual = PsiUpdate.FromXElement(element);
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.National.Region, Region.National);
            Assert.AreEqual(actual.North.Region, Region.North);
            Assert.AreEqual(actual.South.Region, Region.South);
            Assert.AreEqual(actual.East.Region, Region.East);
            Assert.AreEqual(actual.West.Region, Region.West);
            Assert.AreEqual(actual.Central.Region, Region.Central);
        }
    }
}
