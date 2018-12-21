using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.CQP.Plugins.FirstPlugin.model
{
    public class Token
    {
        public Content content { get; set; }

        public class Content
        {
            public string token { get; set; }
        }
    }
}
