using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newcrud
{
    public class Modle
    {
        public virtual int pid { get; protected set; }
        public virtual string pname { get; set; }
        public virtual string city { get; set; }
    }
}