using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchageRateService.Models;
using XmlParser;
using HttpService;

namespace ExchageRateService
{
    public interface IExchangeRateService
    {
        IHttpService HttpService { get; set; }

        IXmlParser XmlParser { get; set; }

        ExchangeResult GetExchangeRate();
    }
}
