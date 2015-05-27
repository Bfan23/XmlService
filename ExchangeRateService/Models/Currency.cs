using System.Xml.Serialization;
using System;
using System.Globalization;

namespace ExchageRateService.Models
{
    
    public class Currency
    {
        [XmlAttribute(AttributeName="CrossOrder")]
        public int CrossOrder { get; set; }

        [XmlAttribute(AttributeName="Kod")]
        public string CodeTR { get; set; }

        [XmlAttribute(AttributeName="CurrencyCode")]
        public string CodeEN { get; set; }

        [XmlElement(ElementName="Unit")]
        public int Unit { get; set; }

        [XmlElement(ElementName="Isim")]
        public string CurrencyNameTR { get; set; }

        [XmlElement(ElementName="CurrencyName")]
        public string CurrencyNameEN { get; set; }

        [XmlElement(ElementName = "ForexBuying")]
        public string ProxyForexBuying { get; set; }

        [XmlIgnore]
        public decimal? ForexBuying
        {
            get { return String.IsNullOrEmpty(ProxyForexBuying) == false ? decimal.Parse(ProxyForexBuying, CultureInfo.CreateSpecificCulture("en-US").NumberFormat) : (decimal?)null; }
            set { ProxyForexBuying = value != null ? string.Format(value.Value.ToString(CultureInfo.CreateSpecificCulture("en-US").NumberFormat)) : null; }
        }

        [XmlElement(ElementName = "ForexSelling")]
        public string ProxyForexSelling { get; set; }

        [XmlIgnore]
        public decimal? ForexSelling
        {
            get { return String.IsNullOrEmpty(ProxyForexSelling) == false ? decimal.Parse(ProxyForexSelling, CultureInfo.CreateSpecificCulture("en-US").NumberFormat) : (decimal?)null; }
            set { ProxyForexSelling = value != null ? string.Format(value.Value.ToString(CultureInfo.CreateSpecificCulture("en-US").NumberFormat)) : null; }
        }

        [XmlElement(ElementName = "BanknoteBuying")]
        public string ProxyBanknoteBuying { get; set; }

        [XmlIgnore]
        public decimal? BanknoteBuying
        {
            get { return String.IsNullOrEmpty(ProxyBanknoteBuying) == false ? decimal.Parse(ProxyBanknoteBuying, CultureInfo.CreateSpecificCulture("en-US").NumberFormat) : (decimal?)null; }
            set { ProxyBanknoteBuying = value != null ? string.Format(value.Value.ToString(CultureInfo.CreateSpecificCulture("en-US").NumberFormat)) : null; }
        }

        [XmlElement(ElementName = "BanknoteSelling")]
        public string ProxyBanknoteSelling { get; set; }

        [XmlIgnore]
        public decimal? BanknoteSelling
        {
            get { return String.IsNullOrEmpty(ProxyBanknoteSelling) == false ? decimal.Parse(ProxyBanknoteSelling, CultureInfo.CreateSpecificCulture("en-US").NumberFormat) : (decimal?)null; }
            set { ProxyBanknoteSelling = value != null ? string.Format(value.Value.ToString(CultureInfo.CreateSpecificCulture("en-US").NumberFormat)) : null; }
        }

        [XmlElement(ElementName = "CrossRateUSD")]
        public string ProxyCrossRateUSD { get; set; }

        [XmlIgnore]
        public decimal? CrossRateUSD
        {
            get { return String.IsNullOrEmpty(ProxyCrossRateUSD) == false ? decimal.Parse(ProxyCrossRateUSD, CultureInfo.CreateSpecificCulture("en-US").NumberFormat) : (decimal?)null; }
            set { ProxyCrossRateUSD = value != null ? string.Format(value.Value.ToString(CultureInfo.CreateSpecificCulture("en-US").NumberFormat)) : null; }
        }

        [XmlElement(ElementName = "CrossRateOther")]
        public string ProxyCrossRateOther { get; set; }

        [XmlIgnore]
        public decimal? CrossRateOther
        {
            get { return String.IsNullOrEmpty(ProxyCrossRateOther) == false ? decimal.Parse(ProxyCrossRateOther, CultureInfo.CreateSpecificCulture("en-US").NumberFormat) : (decimal?)null; }
            set { ProxyCrossRateOther = value != null ?  string.Format(value.Value.ToString(CultureInfo.CreateSpecificCulture("en-US").NumberFormat)) : null; }
        }

    }
}