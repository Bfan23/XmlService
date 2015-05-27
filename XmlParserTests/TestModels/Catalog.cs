using System.Xml.Serialization;

namespace XmlParserTests.TestModels
{
    [XmlRoot(ElementName = "catalog")]
    public class Catalog
    {
        [XmlArrayItem(ElementName="book")]
        [XmlArray(ElementName="book_list")]
        public Book[] BookList { get; set; }
    }

    
}