using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGEnviro;

namespace SGEnviroTest
{
    [TestClass]
    public class ApiTest
    {
        private string apiKey;

        [TestInitialize]
        public void TestInitialize()
        {
            apiKey = ConfigurationManager.AppSettings["ApiKey"];
        }

        [TestMethod]
        public async Task TestApiCanRetrievePsiUpdate()
        {
            var api = new SGEnviroApi(apiKey);
            var result = await api.GetPsiUpdateAsync();
            Assert.IsNotNull(result);
        }
    }
}
