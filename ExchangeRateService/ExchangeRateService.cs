using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchageRateService.Models;
using HttpService;
using XmlParser;

namespace ExchageRateService
{
    public class ExchageRateService: IExchangeRateService
    {

        public IHttpService HttpService { get; set; }

        public IXmlParser XmlParser { get; set; }

        private const string RateServiceUrl = "http://www.tcmb.gov.tr/kurlar/today.xml";

        public ExchangeResult GetExchangeRate()
        {
            HttpService.ServiceUrl = RateServiceUrl;
            string response = HttpService.GetResponse();
            ExchangeResult result = XmlParser.Deserialize<ExchangeResult>(response);

            return result;
        }

    }
}