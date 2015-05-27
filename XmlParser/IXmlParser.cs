using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    public interface IXmlParser
    {
        T Deserialize<T>(string xml) where T : class;
        string Serialize(Object xmlObject);
    }
}
