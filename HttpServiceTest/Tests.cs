using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HttpService;

namespace HttpServiceTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void HttpService()
        {
            IHttpService httpService = new HttpService.HttpService();

            httpService.ServiceUrl = "http://google.com";

            string response = httpService.GetResponse();

            Assert.IsNotNullOrEmpty(response);
        }
    }
}
