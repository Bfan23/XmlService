using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace XmlParser
{
    public class XmlParser: IXmlParser
    {

        public T Deserialize<T>(string xml) where T:class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T)); 

            T xmlObject = (T)xmlSerializer.Deserialize(new StringReader(xml));
            return xmlObject;            
        }

        public string Serialize(Object xmlObject)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(xmlObject.GetType());

            StringBuilder strBuilder = new StringBuilder();
            TextWriter writer = new StringWriter(strBuilder);
            xmlSerializer.Serialize(writer, xmlObject);

            return strBuilder.ToString();
        }

    }
}