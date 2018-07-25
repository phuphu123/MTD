using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTD.Models
{
    public class BaseModel
    {
        public int Code { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }
        public string Redirect { get; set; }
    }

}