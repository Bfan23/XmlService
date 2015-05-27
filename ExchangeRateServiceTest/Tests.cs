using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using ExchageRateService.Models;
using XmlParser;
using HttpService;
using ExchageRateService;

namespace ExchangeRateServiceTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ExchangeRateService()
        {
            IXmlParser xmlParser = new XmlParser.XmlParser();
            IHttpService httpService = new HttpService.HttpService();
            IExchangeRateService exchangeRateService = new ExchageRateService.ExchageRateService();

            exchangeRateService.XmlParser = xmlParser;
            exchangeRateService.HttpService = httpService;

            ExchangeResult result = exchangeRateService.GetExchangeRate();

            Assert.IsNotNullOrEmpty(result.BulletinNo);
            Assert.Greater(result.Date, DateTime.MinValue);
            Assert.IsNotEmpty(result.CurrencyList);

            foreach (Currency currency in result.CurrencyList)
            {
                Assert.IsNotNullOrEmpty(currency.CodeEN);
                if (currency.CodeEN != "XDR")
                {
                    Assert.IsNotNullOrEmpty(currency.CurrencyNameEN);
                    Assert.Greater(currency.ForexBuying,0);
                    Assert.Greater(currency.ForexSelling, 0);
                }
            }
        }
    }
}