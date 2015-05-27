using System.Xml.Serialization;
using System;

namespace ExchageRateService.Models
{
    [XmlRoot(ElementName = "Tarih_Date")]
    public class ExchangeResult
    {


        [XmlAttribute(AttributeName="Tarih")]
        public string ProxyDate { get; set; }

        [XmlIgnore]
        public DateTime Date
        {
            get { return DateTime.ParseExact(this.ProxyDate, "dd.MM.yyyy", null); }
            set { ProxyDate = value.ToString("dd.MM.yyyy"); }
        }

        [XmlAttribute(AttributeName = "Bulten_No")]
        public string BulletinNo { get; set; }

        [XmlElement(ElementName = "Currency")]
        public Currency[] CurrencyList { get; set; }


    }


}