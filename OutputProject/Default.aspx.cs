using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExchageRateService;
using ExchageRateService.Models;
using System.Globalization;

namespace OutputProject
{
    public partial class Default : System.Web.UI.Page
    {

        public static IExchangeRateService exchangeRateService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ExchangeResult rates = exchangeRateService.GetExchangeRate();
            ltRateDate.Text = rates.Date.ToString("dd MMMM dddd yyyy", CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat);
            gvExchangeRates.DataSource = rates.CurrencyList.Select(col => new {
                col.CodeEN,
                col.CrossOrder,
                CurrencyNameEn = col.CurrencyNameEN,
                col.ForexBuying,
                col.ForexSelling,
                col.CrossRateUSD 
            });
            gvExchangeRates.DataBind();
        }
    }
}