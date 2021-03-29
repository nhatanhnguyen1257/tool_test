using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool1.CFRS
{
    public enum TYPE_TEST
    {
        HTML,
        SERVER
    }
    public class CFRS
    {
        public class FormInput
        {
            public string name { get; set; }
            public string method { get; set; }
            public string url { get; set; }
            public string dataOfForm { get; set; }
            public string note { get; set; }
        }

    }
}
