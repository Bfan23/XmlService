using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpService
{
    public interface IHttpService
    {
        string ServiceUrl { get; set; }
        string GetResponse();
    }
}
