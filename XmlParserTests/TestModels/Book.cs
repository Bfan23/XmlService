using System;
using System.Xml.Serialization;

namespace XmlParserTests.TestModels
{
    public class Book
    {
        [XmlAttribute(AttributeName="id")]
        public string ID { get; set; }

        [XmlElement(ElementName="author")]
        public string Author { get; set; }

        [XmlElement(ElementName="title")]
        public string Title { get; set; }

        [XmlElement(ElementName="genre")]
        public string Genre { get; set; }

        [XmlElement(ElementName="price")]
        public decimal Price { get; set; }


        [XmlElement(ElementName="publish_date")]
        public string PublishDateProxy { get; set; }

        [XmlIgnore]
        public DateTime PublishDate
        {
            get { return DateTime.ParseExact(this.PublishDateProxy, "yyyy-MM-dd", null); }
            set { this.PublishDateProxy = value.ToString("yyyy-MM-dd"); }
        }

        [XmlElement(ElementName="description")]
        public string Description { get; set; }
        
    }
}
