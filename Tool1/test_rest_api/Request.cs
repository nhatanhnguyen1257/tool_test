using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool1.test_rest_api
{
    public class Request
    {
        public string method { get; set; }

        public string requestUrl { get; set; }

        public string headers { get; set; }

        public string body { get; set; }

    }
}
